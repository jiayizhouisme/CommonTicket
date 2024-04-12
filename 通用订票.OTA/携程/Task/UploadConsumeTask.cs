using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Model;

namespace 通用订票.JobTask
{
    public class UploadConsumeTask : IJob
    {
        private readonly ICacheOperation _cache;
        public UploadConsumeTask(ICacheOperation _cache)
        {
            this._cache = _cache;
        }
        public async System.Threading.Tasks.Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            var list = await _cache.GetList<XieChengTicketConsumeRequest>("TicketConsumed",0);
            
            if (list == null || list.Count == 0)
            {
                await Task.CompletedTask;
                return;
            }
            var orderIds = list.GroupBy(a => a.raw.otaOrderId).Select(a => a.Key);

            foreach (var id in orderIds)
            {
                var item = list.Where(a => a.raw.otaOrderId == id)
                    .OrderByDescending(a => a.request.header.requestTime).FirstOrDefault();
               await item.request.Request();
            }
            await _cache.Del("TicketConsumed");
        }
    }
}
