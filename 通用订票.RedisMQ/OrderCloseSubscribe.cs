using Core.Auth;
using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProtoBuf.Meta;
using StackExchange.Redis;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
using 通用订票Order.Entity;

namespace 通用订票.RedisMQ
{
    public class OrderCloseSubscribe : IRedisSubscribe
    {
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ILogger<OrderCloseSubscribe> _logger;
        private readonly ICacheOperation _cache;
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventPublisher eventPublisher;

        public OrderCloseSubscribe(ILogger<OrderCloseSubscribe> _logger, 
            IServiceProvider _serviceProvider,
            ICacheOperation _cache,
            IJsonSerializerProvider jsonSerializerProvider,
            IEventPublisher eventPublisher)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this.eventPublisher = eventPublisher;
        }

        [SubscribeDelay("CloseOrder")]
        public async Task CloseOrder(string json)
        {
            _logger.LogInformation("订单关闭");
            OrderClose data = jsonSerializerProvider.Deserialize<OrderClose>(json);
            if (data == null)
            {
                return;
            }

            Core.Entity.Order order = null;
            string lockerId = Guid.NewGuid().ToString();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);

            using (var scope = _serviceProvider.CreateScope())
            {
                
                #region 获取services
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var o_service = factory.GetOrderService(_orderProvider);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
                o_service.SetUserContext(data.userId);
                DbContext dbContext = Db.GetDbContext(scope.ServiceProvider);
                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
                #endregion
                var lo = _cache.Lock("OrderLocker_" + data.trade_no, lockerId).Result;
                order = o_service.GetOrderById(data.trade_no).Result;
                var orderInfo = jsonSerializerProvider.Deserialize<OrderInfo>(order.extraInfo);

                var billService = ServiceFactory.GetSaasService<IWechatBillService,WechatBill>(scope.ServiceProvider,data.tenantId);

                try
                {
                    if (order.status != OrderStatus.未付款)
                    {
                        throw new Exception("订单已支付或不存在");
                    }
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        var o = o_service.CancelOrder(order).Result;
                        if (o == null)
                        {
                            throw new Exception("订单已支付或不存在");
                        }
                        var l = _cache.Lock("OrderCloseLock:" + order.objectId, order.objectId).Result;

                        var stock = s_service.checkStock(order.objectId).Result;
                        stock.sale -= orderInfo.ids.Count();
                        //if (stock.sale < 0)
                        //{
                        //    stock.sale = 0;
                        //}
                        await s_service.UpdateNow(stock);
                        await billService.UpdateStatus(OrderStatus.已关闭,order.trade_no);

                        await s_service.DelStockFromCache(stock.id);
                        await transaction.CommitAsync();
                    }
                    var onOrderClosed = new OnOrderClosed() { order = order, tenantId = data.tenantId, userId = data.userId };
                    await eventPublisher.PublishAsync(new OnOrderClosedEvent(onOrderClosed));

                }
                catch (Exception e1)
                {

                }
                finally
                {
                    var saleResult = await s_service.SaleStock(order.objectId, -orderInfo.ids.Count());
                    await _cache.ReleaseLock("OrderLocker_" + data.trade_no, lockerId.ToString());
                    await _cache.ReleaseLock("OrderCloseLock:" + order.objectId, order.objectId);
                }
                
            }
            await Task.CompletedTask;
        }
    }
}