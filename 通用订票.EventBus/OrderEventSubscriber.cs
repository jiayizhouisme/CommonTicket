using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion;
using Furion.DependencyInjection;
using Furion.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
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
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IEventPublisher eventPublisher;
        private readonly ILogger<OrderEventSubscriber> _logger;
        private readonly IQueuePushInfo _queue;
        public OrderEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<OrderEventSubscriber> logger,
            IQueuePushInfo _queue,
            IEventPublisher eventPublisher)
        {
            this.ScopeFactory = scopeFactory;
            this._queue = _queue;
            this.eventPublisher = eventPublisher;
            _logger = logger;
        }

        [EventSubscribe("CreateOrder")]
        public async Task CreateOrder(EventHandlerExecutingContext context)
        {
            DateTime now = DateTime.Now;
            var todo = context.Source;
            var data = (Entity.CreateOrder)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _OrderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();

            var o_service = factory.GetOrderService(_OrderProvider);

            o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
            o_service.SetUserContext(data.userId);
            #endregion

            Core.Entity.Order order = null;

            try
            {
                order = await o_service.CreateOrder(data.id, data.StockName, data.price);
            }
            catch (Exception e)
            {
                var fail = new OrderCreateFail()
                {
                    order = order,
                    app = data.app,
                    count = data.count
                };
                await eventPublisher.PublishAsync(new OrderCreateFailEvent(fail));
                throw e;
            }

            var startTime = now.AddDays(data.app.day).Date.Add(data.app.startTime.TimeOfDay);
            var endTime = now.AddDays(data.app.day).Date.Add(data.app.endTime.TimeOfDay);

            var CreateTickets = new TicketCreateQueueEntity(new TicketCreate()
            {
                startTime = startTime,
                endTime = endTime,
                order = order,
                tenantId = data.tenantId,
                uid = data.ids,
                userid = data.userId
            });

            await _queue.PushMessage(CreateTickets);

            var CloseOrder = new OrderCloseQueueEntity(
                            new OrderClose()
                            {
                                trade_no = order.trade_no,
                                appid = data.id,
                                delay = 10,
                                tenantId = data.tenantId,
                                count = data.count
                            }
                            );
            await _queue.PushMessageDelay(CloseOrder, DateTime.Now.AddSeconds(60));

        }

        [EventSubscribe("OrderCreateFail")]
        public async Task OrderCreateFail(EventHandlerExecutingContext context)
        {

        }
    }
}
