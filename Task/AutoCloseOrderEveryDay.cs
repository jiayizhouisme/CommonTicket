using Furion;
using Furion.DatabaseAccessor;
using Furion.Schedule;
using InitQ.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using Core.Services.ServiceFactory;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.JobTask;
using static System.Runtime.InteropServices.JavaScript.JSType;
using 通用订票.Application.System.Factory.Service;
using Core.Queue.IQueue;
using 通用订票.RedisMQ.Entity;

namespace 通用订票.JobTask
{
    public class AutoCloseOrderEveryDay : IJob
    {
        private readonly ILogger<AutoCloseOrderEveryDay> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IQueuePushInfo _queue;

        public AutoCloseOrderEveryDay(ILogger<AutoCloseOrderEveryDay> _logger, IServiceProvider _serviceProvider, IQueuePushInfo _queue)
        {
            this._logger = _logger;
            this._serviceProvider = _serviceProvider;
            this._queue = _queue;
        }

        public async System.Threading.Tasks.Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();

            var te = Db.GetRepository<Tenant, MultiTenantDbContextLocator>(scope.ServiceProvider);
            var tenants = await te.AsQueryable().Select(a => a.Host).AsNoTracking().ToListAsync();
            foreach (var item in tenants)
            {
                await CloseOrdersByid(scope, item);

            }
        }

        private async Task CloseOrdersByid(IServiceScope scope, string id)
        {
            var s_service = ServiceFactory.GetSaasService<IAppointmentService, Appointment>(scope.ServiceProvider, id);
            var o_service = ServiceFactory.GetSaasService<IMyOrderServices, Core.Entity.Order>(scope.ServiceProvider, id);
            var te = Db.GetRepository<Tenant, MultiTenantDbContextLocator>(scope.ServiceProvider);
            var now = DateTime.Now.AddMinutes(0);

            var orders = await o_service.GetQueryableNt(a => a.status == 通用订票Order.Entity.OrderStatus.未付款 &&
            now.CompareTo(a.createTime.Value) > 0).Select(a => new { a.objectId, a.trade_no }).ToListAsync();
            foreach (var order in orders)
            {
                var app = await s_service.GetAppointmentById(order.objectId);

                var CreateOrder = new OrderCloseQueueEntity(new OrderClose() { trade_no = order.trade_no, app = app, tickets = null, delay = 10, tenantId = id });
                await _queue.PushMessageDelay(CreateOrder, DateTime.Now.AddSeconds(10));
            }
        }
    }
}
