using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Core.SignalR;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;

namespace 通用订票.RedisMQ
{
    public class OrderCreateSubscribe : IRedisSubscribe
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        public OrderCreateSubscribe(
            IHubContext<ChatHub> _hubContext,
            IEventPublisher _eventPublisher,
            IJsonSerializerProvider jsonSerializerProvider)
        {
            this._hubContext = _hubContext;
            this._eventPublisher = _eventPublisher;
            this.jsonSerializerProvider = jsonSerializerProvider;
        }

        [Subscribe("CreateOrder")]
        public async Task CreateOrder(string json)
        {
            BeforeCreateOrder data = jsonSerializerProvider.Deserialize<BeforeCreateOrder>(json);
            if (data == null)
            {
                return;
            }
            try
            {
                await _eventPublisher.PublishAsync(new OnOrderCreateEvent(data));
            }
            catch (Exception e)
            {
                throw e;
            }
            
            await Task.CompletedTask;
        }
        private async Task sendMessage(RealOnlineClient client, object message)
        {
            if (client != null && client.ConnId != null)
            {
                await _hubContext.Clients.Client(client.ConnId).SendAsync("ReceiveMessage",message);
            }
        }
    }
}