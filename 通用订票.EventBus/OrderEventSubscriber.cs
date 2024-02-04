using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Core.SignalR;
using Furion;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus
{
    public class OrderEventSubscriber : IEventSubscriber, ISingleton
    {
        private readonly ICacheOperation _cache;
        private readonly IQueuePushInfo _queue;
        private readonly IServiceScopeFactory ScopeFactory;


        public OrderEventSubscriber(
            ICacheOperation _cache,
            IQueuePushInfo _queue,
            IServiceScopeFactory ScopeFactory
            )
        {
            this._cache = _cache;
            this._queue = _queue;
            this.ScopeFactory = ScopeFactory;
        }

        [EventSubscribe("OnOrderCreated")]
        public async Task OnOrderCreated(EventHandlerExecutingContext context)
        {        
            var todo = context.Source;
            var data = (Entity.OnOrderCreated)todo.Payload;

            var CloseOrder = new OrderCloseQueueEntity(
                            new OrderClose()
                            {
                                trade_no = data.order.trade_no,
                                appid = data.app.id,
                                delay = 10,
                                tenantId = data.tenantId
                            }
            );
            await _queue.PushMessageDelay(CloseOrder, DateTime.Now.AddSeconds(60));
        }

        [EventSubscribe("OnTicketCloseFailed")]
        public async Task OnTicketCloseFailed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnTicketCloseFailed)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();

            var o_service = factory.GetOrderService(_orderProvider);

            o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
            #endregion
            await o_service.OnCloseException(data.order);
        }

    }
}
