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
    public class StockEventSubscriber : IEventSubscriber,ISingleton
    {
        private readonly ILogger<StockEventSubscriber> _logger;
        public StockEventSubscriber(ILogger<StockEventSubscriber> logger)
        {
            _logger = logger;
        }

        [EventSubscribe("Stock:CheckSucceed")]
        public async Task StockCheckSucceed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            _logger.LogInformation("创建一个 ToDo：{Name}", todo.Payload);
            await Task.CompletedTask;
        }

        [EventSubscribe("Stock:CheckFailed")]
        public async Task StockCheckFailed(EventHandlerExecutedContext context)
        {
            var todo = context.Source;
            _logger.LogInformation("创建一个 ToDo：{Name}", todo.Payload);
            await Task.CompletedTask;
        }
    }
}
