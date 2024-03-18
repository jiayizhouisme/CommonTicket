using Core.Cache;
using Core.Queue.IQueue;
using Core.SignalR;
using DotNetCore.CAP;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus
{
    public class LockerAndQueueSubscriber : IEventSubscriber, ISingleton
    {
        private readonly ICacheOperation _cache;
        private readonly ISignalRUserService userapp;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IJsonSerializerProvider jsonSerializerProvider;

        public LockerAndQueueSubscriber(
            ICacheOperation _cache,
            ISignalRUserService userapp,
            IHubContext<ChatHub> _hubContext,
            IJsonSerializerProvider jsonSerializerProvider
            )
        {
            this._cache = _cache;
            this.userapp = userapp; 
            this._hubContext = _hubContext;
            this.jsonSerializerProvider = jsonSerializerProvider;
        }

        [EventSubscribe("OnOrderCreateFailed")]

        public async Task Global_OnOrderCreateFailed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (Entity.OnOrderCreateFailed)todo.Payload;

            await _cache.Decrby("QueueIn_" + data.app.id, data.count);
            var client = userapp.isOnline(data.userId.ToString());
            if (client != null)
            {
                await _hubContext.Clients.Client(client.ConnId).SendAsync("ReceiveMessage",
                    jsonSerializerProvider.Serialize(new
                    {
                        code = 1,
                        message = "订单创建失败"
                    }));
            }

        }

        [EventSubscribe("OnOrderCreated")]
        public async Task Global_OnOrderCreated(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (Entity.OnOrderCreated)todo.Payload;

            await _cache.Decrby("QueueIn_" + data.app.id, data.ids.Count);

            var client = userapp.isOnline(data.userId.ToString());
            if (client != null)
            {
                await _hubContext.Clients.Client(client.ConnId).SendAsync("ReceiveMessage",
                    jsonSerializerProvider.Serialize(new
                    {
                        code = 1,
                        message = "订单创建成功",
                        order = data.order
                    }));
            }


        }
    }
}
