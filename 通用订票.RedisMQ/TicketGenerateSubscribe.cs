using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.JsonSerialization;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.Extensions.DependencyInjection;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Procedure.Entity;

namespace 通用订票.RedisMQ
{
    public class TicketGenerateSubscribe : IRedisSubscribe
    {
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICacheOperation _cache;
        public TicketGenerateSubscribe(IServiceProvider _serviceProvider, ICacheOperation _cache, IJsonSerializerProvider jsonSerializerProvider)
        {
            this._serviceProvider = _serviceProvider;
            this._cache = _cache;
            this.jsonSerializerProvider = jsonSerializerProvider;
        }

        [Subscribe("CreateTickets")]
        public async Task CreateTickets(string json)
        {
            var data = jsonSerializerProvider.Deserialize<TicketCreate>(json);
            if (data == null)
            {
                await Task.CompletedTask;
                return;
            }
            string lockerId = Guid.NewGuid().ToString();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope())
            {
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                var o_service = factory.GetOrderService(_orderProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Core.Entity.Ticket>(scope.ServiceProvider, t_service, data.tenantId);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);

                t_service.SetUserContext(data.userid);
                var lo = await _cache.Lock("OrderLocker_" + data.order.trade_no, lockerId);
                var order = await o_service.GetOrderById(data.order.trade_no);
                if (order.status != 通用订票Order.Entity.OrderStatus.已关闭 &&
                    order.status != 通用订票Order.Entity.OrderStatus.已退款 &&
                    order.status != 通用订票Order.Entity.OrderStatus.退款中 &&
                    order.status != 通用订票Order.Entity.OrderStatus.一部分退款)
                {
                    if (order.status == 通用订票Order.Entity.OrderStatus.已付款)
                    {
                        await t_service.GenarateTickets(data.exhibitionId,data.startTime, data.endTime, data.order, data.uid.ToArray(), data.exhibitions,TicketStatus.未使用);
                    }
                    else
                    {
                        await t_service.GenarateTickets(data.exhibitionId,data.startTime, data.endTime, data.order, data.uid.ToArray(), data.exhibitions, TicketStatus.未激活);
                    }
                }
            }
            await _cache.ReleaseLock("OrderLocker_" + data.order.trade_no, lockerId);
            await _cache.ReleaseLock("UserLock_" + data.userid, data.userid.ToString());
            await Task.CompletedTask;
        }
    }
}
