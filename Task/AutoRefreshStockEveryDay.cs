using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.JobTask
{
    /// <summary>
    /// 每天自动更新最新的库存
    /// </summary>
    public class AutoRefreshStockEveryDay : IJob
    {
        private readonly ILogger<AutoRefreshStockEveryDay> _logger;
        private readonly IServiceProvider _serviceProvider;
        private DbContext dbContext;
        public AutoRefreshStockEveryDay(ILogger<AutoRefreshStockEveryDay> _logger, IServiceProvider _serviceProvider)
        {
            this._logger = _logger;
            this._serviceProvider = _serviceProvider;
        }

        public async System.Threading.Tasks.Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();
            var te = Db.GetRepository<Tenant, MultiTenantDbContextLocator>(scope.ServiceProvider);
            var tenants = await te.AsQueryable().Select(a => a.Host).AsNoTracking().ToListAsync();
            foreach (var item in tenants)
            {
                await RefreshStockByid(scope,item);

            }
            _logger.LogInformation("每日刷新");
        }

        private async Task RefreshStockByid(IServiceScope scope,string id)
        {
            dbContext = Db.GetDbContext(scope.ServiceProvider);
            var e_service = ServiceFactory.GetSaasService<IExhibitionService, Exhibition>(scope.ServiceProvider, id);

            var factory = SaaSServiceFactory.GetServiceFactory(id);

            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IAppointmentService>>();
            var app_service = factory.GetStockService(_stockProvider);
            app_service = ServiceFactory.GetNamedSaasService<IAppointmentService, Appointment>(scope.ServiceProvider, app_service, id);
            
            var exhibitions = await e_service.GetQueryableNt(a => a != null).Select(a => a.id).ToArrayAsync();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in exhibitions)
                    {
                        await app_service.RefreshAppoints(item);
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }
            }
        }
    }
}