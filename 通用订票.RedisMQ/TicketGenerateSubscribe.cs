using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;

namespace 通用订票.RedisMQ
{
    public class TicketGenerateSubscribe : IRedisSubscribe
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICacheOperation _cache;
        public TicketGenerateSubscribe(IServiceProvider _serviceProvider, ICacheOperation _cache)
        {
            this._serviceProvider = _serviceProvider;
            this._cache = _cache;
        }

        [Subscribe("CreateTickets")]
        public async Task CreateTickets(string json)
        {
            var data = JsonConvert.DeserializeObject<TicketCreate>(json);
            if (data == null)
            {
                await Task.CompletedTask;
                return;
            }

            string lockerId = Guid.NewGuid().ToString();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope())
            {
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyTicketService>>();
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyOrderServices>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                var o_service = factory.GetOrderService(_orderProvider);
                t_service = ServiceFactory.GetNamedSaasService<IMyTicketService, Core.Entity.Ticket>(scope.ServiceProvider, t_service, data.tenantId);
                o_service = ServiceFactory.GetNamedSaasService<IMyOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);

                t_service.SetUserContext(data.userid);
                var lo = await _cache.Lock("OrderLocker_" + data.order.trade_no, lockerId);
                var order = await o_service.GetOrderById(data.order.trade_no);
                if (order.status != 通用订票Order.Entity.OrderStatus.已关闭 &&
                    order.status != 通用订票Order.Entity.OrderStatus.已退款 &&
                    order.status != 通用订票Order.Entity.OrderStatus.一部分退款)
                {
                    if (order.status == 通用订票Order.Entity.OrderStatus.已付款)
                    {
                        await t_service.GenarateTickets(data.startTime, data.endTime, data.order, data.uid.ToArray(), Ticket.Entity.TicketStatus.未使用);
                    }
                    else
                    {
                        await t_service.GenarateTickets(data.startTime, data.endTime, data.order, data.uid.ToArray(), Ticket.Entity.TicketStatus.未激活);
                    }
                }
            }
            await _cache.ReleaseLock("OrderLocker_" + data.order.trade_no, lockerId);
            await _cache.ReleaseLock("UserLock_" + data.userid, null);
            await Task.CompletedTask;
        }
    }
}
