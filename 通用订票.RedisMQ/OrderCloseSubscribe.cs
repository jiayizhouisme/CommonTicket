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
using StackExchange.Redis;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;
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
            var lo = _cache.Lock("OrderLocker_" + data.trade_no, lockerId).Result;
            using (var scope = _serviceProvider.CreateScope())
            {
                #region 获取services
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var o_service = factory.GetOrderService(_orderProvider);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
                #endregion
                try
                {
                    order = o_service.GetOrderById(data.trade_no).Result;
                    if (order.status != OrderStatus.未付款)
                    {
                        throw new Exception("");
                    }
                    var o = o_service.CancelOrder(order).Result;
                    if (o == null)
                    {
                        throw new Exception("订单已支付或不存在");
                    }
                    var orderClosed = new OnOrderClosed() { order = order,tenantId = data.tenantId };
                    await eventPublisher.PublishAsync(new OnOrderClosedEvent(orderClosed));
                }
                catch (Exception e1)
                {
 
                }
                finally
                {

                    await _cache.ReleaseLock("OrderLocker_" + data.trade_no, lockerId.ToString());
                }
                
            }
            await Task.CompletedTask;
        }
    }
}