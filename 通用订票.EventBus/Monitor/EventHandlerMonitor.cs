using Furion.EventBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.EventBus.Monitor
{
    public class EventHandlerMonitor : IEventHandlerMonitor
    {
        private readonly ILogger<EventHandlerMonitor> _logger;
        public EventHandlerMonitor(ILogger<EventHandlerMonitor> logger)
        {
            _logger = logger;
        }

        public Task OnExecutingAsync(EventHandlerExecutingContext context)
        {
            _logger.LogInformation("执行之前：{EventId},来源:{Source}", context.Source.EventId, context.HandlerMethod);
            
            return Task.CompletedTask;
        }

        public Task OnExecutedAsync(EventHandlerExecutedContext context)
        {
            _logger.LogInformation("执行之后：{EventId},来源:{Source}", context.Source.EventId, context.HandlerMethod);

            if (context.Exception != null)
            {
                _logger.LogError(context.Exception, "执行出错啦：{EventId}", context.Source.EventId);
            }

            return Task.CompletedTask;
        }
    }
}
