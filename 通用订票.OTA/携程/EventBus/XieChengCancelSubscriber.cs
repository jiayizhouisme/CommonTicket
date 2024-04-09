using Core.Cache;
using Core.Services.ServiceFactory;
using Core.User.Service;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.RemoteRequest.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;

namespace 通用订票.EventBus
{
    public class XieChengCancelSubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        
        public XieChengCancelSubscriber(
            IServiceScopeFactory scopeFactory)
        {
            this.ScopeFactory = scopeFactory;
        }

        [EventSubscribe("XieChengCancelConfirm")]
        public async Task XieChengCancelConfirm(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (XieChengCancelOrder)todo.Payload;
            
            using (var scope = this.ScopeFactory.CreateScope())
            {
                #region 获取services
                var tenantService = scope.ServiceProvider.GetService<TenantService>();
                var xiechengService = scope.ServiceProvider.GetService<IXieChengOTAOrderService>();
                var tenant = await tenantService.GetTenantByHost(data.tenant_id);
                xiechengService.SetDbConnectString(tenant.ConnectionString);
                #endregion
                await xiechengService.CancleOrderConfirm(data);
            }
        }
    }
}
