using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Application.System.Factory.Service;
using Newtonsoft.Json;
using 通用订票.Application.System.Models;
using Core.Cache;

namespace 通用订票.RedisMQ
{
    public class TicketGenerateSubscribe : IRedisSubscribe
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MyBeetleX _cache;
        public TicketGenerateSubscribe(IServiceProvider _serviceProvider, MyBeetleX _cache) {
            this._serviceProvider = _serviceProvider;
            this._cache = _cache;
        }

        [Subscribe("CreateTickets")]
        public async Task CreateTickets(string json)
        {
            var data = JsonConvert.DeserializeObject<TicketCreate>(json);
            if (data == null)
            {
                await Task.CompletedTask;
                return;
            }
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope())
            {
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IMyTicketService, Core.Entity.Ticket>(scope.ServiceProvider, t_service, data.tenantId);
                t_service.SetUserContext(data.userid);
                await t_service.GenarateTickets(data.startTime,data.endTime,data.order,data.uid.ToArray());
            }
            await _cache.ReleaseLock("UserLock_" + data.userid, null);
            await Task.CompletedTask;
        }
    }
}
