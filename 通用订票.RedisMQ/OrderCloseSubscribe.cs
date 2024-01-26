using Furion;
using Furion.DatabaseAccessor;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using System;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.Entity;
using 通用订票Order.Entity;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using ProtoBuf.Serializers;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Factory.Service;

namespace 通用订票.RedisMQ
{
    public class OrderCloseSubscribe : IRedisSubscribe
    {
        private readonly ILogger<OrderCloseSubscribe> _logger;
        private readonly MyBeetleX _cache;
        private readonly IServiceProvider _serviceProvider;

        public OrderCloseSubscribe(ILogger<OrderCloseSubscribe> _logger, IServiceProvider _serviceProvider,MyBeetleX _cache)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
        }

        [SubscribeDelay("CloseOrder")]
        public async Task CloseOrder(string json)
        {
            _logger.LogInformation("订单关闭");
            OrderClose data = JsonConvert.DeserializeObject<OrderClose>(json);
            if (data == null)
            {
                return;
            }

            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope())
            {
                DbContext dbContext = Db.GetDbContext(scope.ServiceProvider);
                #region 获取services
                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IAppointmentService>>();
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyOrderServices>>();
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyTicketService>>();

                var s_service = factory.GetStockService(_stockProvider);
                var o_service = factory.GetOrderService(_orderProvider);
                var t_service = factory.GetTicketService(_ticketProvider);

                s_service = ServiceFactory.GetNamedSaasService<IAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
                o_service = ServiceFactory.GetNamedSaasService<IMyOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
                t_service = ServiceFactory.GetNamedSaasService<IMyTicketService, Core.Entity.Ticket>(scope.ServiceProvider, t_service, data.tenantId);
                #endregion

                Guid lockerId = Guid.NewGuid();
                var lo = _cache.Lock("OrderLocker_" + data.trade_no, lockerId).Result;
                var order = o_service.GetOrderById(data.trade_no).Result;
                if (order.status != OrderStatus.未付款)
                {
                    await _cache.ReleaseLock("OrderLocker_" + data.trade_no, lockerId.ToString());
                    throw new Exception("");
                }
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = o_service.CancelOrder(order).Result;
                        if (o == null)
                        {
                            throw new Exception("订单已支付或不存在");
                        }
                        data.tickets = t_service.GetTickets(o.trade_no).Result;

                        t_service.DisableTickets(data.tickets).Wait();

                        //if (data.tickets != null)
                        //{
                        //    foreach (var ticket in data.tickets)
                        //    {
                        //        //ticket.isDeleted = true;
                        //        var _result = t_service.DisableTicket(ticket).Result;
                        //    }
                        //}

                        var app = s_service.SaleStock(data.app.id, -data.tickets.Count).Result;
                        if (app == null)
                        {
                            throw new Exception("app不能为空");
                        }

                        await transaction.CommitAsync();
                        await t_service.AfterTicketToke(order.trade_no);
                    }
                    catch (Exception e1)
                    {
                        await o_service.AfterOrderToke(order.trade_no);
                        await s_service.DelStockFromCache(data.app.id);
                        //await OrderCancelTask(orderid, appid, tickets, delay);//失败循环关闭
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception e) { }
                    }
                    finally
                    {

                        await _cache.ReleaseLock("OrderLocker_" + data.trade_no, lockerId.ToString());
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}