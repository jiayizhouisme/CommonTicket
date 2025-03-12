using Core.Auth;
using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.RemoteRequest.Extensions;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Serializers;
using StackExchange.Redis;
using System.Net.Sockets;
using System.Security.Policy;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;

namespace 通用订票.JobTask
{
    public class MachineTicketVerifiedEvent : IEventSubscriber, ISingleton
    {
        private readonly ILogin login;
        private readonly IServiceProvider _serviceProvider;
        public MachineTicketVerifiedEvent(ILogin login, IServiceProvider serviceProvider)
        {
            this.login = login;
            _serviceProvider = serviceProvider;
        }

        [EventSubscribe(nameof(OnMachineTicketVerifiedEvent),NumRetries = 0)]
        public async Task verify(EventHandlerExecutingContext context)
        {
            var device = (OnMachineTicketVerified)context.Source.Payload;
            if (device.Device.httpMethod == Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod.Get)
            {
                var request = await device.Device.url.OnRequesting((req, mes) =>
                {
                    login.Login().Wait();
                    var token = "Bearer " + login.Token;
                    mes.AppendHeaders(new { Authorization = token });

                }).GetAsync();
            }else if (device.Device.httpMethod == Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod.Post)
            {
                var request = await device.Device.url.OnRequesting((req, mes) =>
                {
                    login.Login().Wait();
                    var token = "Bearer " + login.Token;
                    mes.AppendHeaders(new { Authorization = token });

                }).PostAsync();
            }

            using (var scope = this._serviceProvider.CreateScope())
            {
                var eers = ServiceFactory.GetSaasService<IEnterExistRecordsService, EnterExistRecords>(scope.ServiceProvider, device.tenantId);
                await eers.Record(device.userinfo_id,device.updateTime,device.Device.type);
            }

        }
    }
}
