using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Serializers;
using StackExchange.Redis;
using System.Net.Sockets;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;

namespace 通用订票.JobTask
{
    public class TicketVerifyEvent : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        public TicketVerifyEvent( IServiceScopeFactory ScopeFactory)
        {
            this.ScopeFactory = ScopeFactory;
        }

        [EventSubscribe("TicketVerifyEvent")]
        public async Task verify(EventHandlerExecutingContext context)
        {
            var ticket = (TicketVerifyEventModel)context.Source.Payload;
            if (ticket.type == OTAType.XieCheng)
            {
                using (var scope = ScopeFactory.CreateScope())
                {
                    var service = ServiceFactory.GetSaasService<IXieChengOTAOrderService, XieChengOrder>(scope.ServiceProvider, ticket.tenant_id);
                    service.SetTenant(ticket.tenant_id);

                    await service.Verify(ticket.ticketNumber, ticket.count);
                }
            }
        }
    }
}
