using Furion.DependencyInjection;
using Furion.EventBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.EventBus
{
    public class OrderEventSubscriber : IEventSubscriber,ISingleton
    {
        private readonly ILogger<OrderEventSubscriber> _logger;
        public OrderEventSubscriber(ILogger<OrderEventSubscriber> logger)
        {
            _logger = logger;
        }

        [EventSubscribe("Order:BeforeCreate")]
        public async Task BeforeCreate(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            _logger.LogInformation("创建一个 ToDo：{Name}", todo.Payload);
            await Task.CompletedTask;
        }

        [EventSubscribe("Order:AfterCreated")]
        public async Task AfterCreated(EventHandlerExecutedContext context)
        {
            var todo = context.Source;
            _logger.LogInformation("创建一个 ToDo：{Name}", todo.Payload);
            await Task.CompletedTask;
        }

        private void CreateSucceed()
        {

        }

        private void CreateFail()
        {

        }
    }
}
