using Core.Auth;
using Core.Cache;
using Core.Services.ServiceFactory;
using DotNetCore.CAP.Dashboard;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProtoBuf.Meta;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus
{
    public class OrderEventSubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IWechatPayService wechatPayService;
        private readonly ILogger<OrderEventSubscriber> _logger;
        private readonly IEventPublisher eventPublisher;
        private readonly ICacheOperation cache;
        public OrderEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<OrderEventSubscriber> logger,
            IEventPublisher eventPublisher,
            IWechatPayService wechatPayService,
            ICacheOperation cache
            )
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;
            this.eventPublisher = eventPublisher;
            this.wechatPayService = wechatPayService;
            this.cache = cache;
        }

        [EventSubscribe("OnOrderPreRefunded")]
        public async Task Order_OnOrderPreRefunded(EventHandlerExecutingContext context)
        {
            var data = (OnOrderPreRefunded)context.Source.Payload;

            using var scope = this.ScopeFactory.CreateScope();

            #region 获取services
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            DbContext dbContext = Db.GetDbContext(scope.ServiceProvider);
            var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
            var o_service = factory.GetOrderService(_orderProvider);
            o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
            o_service.SetUserContext(data.userId);
            var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
            var t_service = factory.GetTicketService(_ticketProvider);
            t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenantId);
            t_service.SetUserContext(data.userId);
            var m_service = ServiceFactory.GetSaasService<IMultiTicketService, MultiTicket>(scope.ServiceProvider,data.tenantId);
            var configService = ServiceFactory.GetSaasService<IWechatMerchantConfigService, WechatMerchantConfig>(scope.ServiceProvider, data.tenantId);
            var refundBillService = ServiceFactory.GetSaasService<IWechatRefundBillService, WechatBillRefund>(scope.ServiceProvider, data.tenantId);
            #endregion

            string lockerId = Guid.NewGuid().ToString();
            var lo = await cache.Lock("OrderLocker_" + data.order.trade_no, lockerId);
            var tickets = await t_service.GetTickets(data.order.trade_no);

            foreach (var ticket in tickets)
            {
                int uselessCount = ticket.usedCount + ticket.cancelCount;
                if (ticket.stauts != Base.Entity.TicketStatus.未使用 || uselessCount > 0)
                {
                    //票之前已被使用,恢复订单状态
                    await RecoverOrder(o_service, data.order);
                    await cache.ReleaseLock("OrderLocker_" + data.order.trade_no, lockerId);
                    return;
                }
            }

            if (data.order.amount > 0)
            {
                //如果不是免费的票开始走退款流程 
                var config = await configService.GetConfig();
                try
                {
                    var refundResult = await wechatPayService.Refund(data.billRefund, data.bill, config);
                    if (refundResult == null)
                    {
                        throw new Exception("退款失败");
                    }
                }
                catch (Exception e)
                {
                    await RecoverOrder(o_service, data.order);
                    await refundBillService.UpdateStatus(RefundStatus.退款失败, data.bill.paymentId);
                    throw e;
                }
                finally
                {
                    await cache.ReleaseLock("OrderLocker_" + data.order.trade_no, lockerId);
                }
            }

            try
            {
                var order = await o_service.RefundOrder(data.order); //退款开始
                await t_service.DisableTickets(tickets);
                if (order == null)
                {
                    throw new Exception("退款失败");
                }
                //恢复占用的app库存并且冻结所有可用票据
                var onOrderRefuned = new OnOrderRefunded()
                { order = order,billRefund = data.billRefund, tenantId = data.tenantId, userId = data.userId};
                await eventPublisher.PublishAsync(new OnOrderRefundedEvent(onOrderRefuned));
            }
            catch (Exception ex)
            {
                await RecoverOrder(o_service, data.order);
                await refundBillService.UpdateStatus(RefundStatus.退款失败, data.bill.paymentId);
                throw ex;
            }
            finally
            {
                await cache.ReleaseLock("OrderLocker_" + data.order.trade_no, lockerId);
            }
        }
           

        private async Task RecoverOrder(IDefaultOrderServices o_service,Core.Entity.Order order)
        {
            order.status = 通用订票Order.Entity.OrderStatus.已付款;
            await o_service.UpdateNow(order);
        }
    }
}
