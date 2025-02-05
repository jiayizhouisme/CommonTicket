﻿using Core.TenantJob;
using Furion;
using Furion.DatabaseAccessor;
using Furion.Schedule;
using Microsoft.Extensions.DependencyInjection;
using 通用订票.Core.Entity;

namespace 通用订票.JobTask
{
    public class DbJobPersistence : IJobPersistence, IDisposable
    {
        private readonly IServiceScope _serviceScope;
        private readonly IRepository<Core.Entity.JobDetail,MultiTenantDbContextLocator> _jobRepository;
        private readonly IRepository<Core.Entity.JobTrigger, MultiTenantDbContextLocator> _triggerRepository;

        public DbJobPersistence(IServiceScopeFactory serviceScope)
        {
            _serviceScope = serviceScope.CreateScope();
            var services = _serviceScope.ServiceProvider;

            _jobRepository = services.GetService<IRepository<Core.Entity.JobDetail, MultiTenantDbContextLocator>>();
            _triggerRepository = services.GetService<IRepository<JobTrigger, MultiTenantDbContextLocator>>();
        }

        public async Task<IEnumerable<SchedulerBuilder>> PreloadAsync(CancellationToken stoppingToken)
        {
            var allJobs = App.EffectiveTypes.ScanToBuilders();

            // 若数据库不存在任何作业，则直接返回
            if (!_jobRepository.Any(u => true)) return allJobs;

            // 遍历所有定义的作业
            foreach (var schedulerBuilder in allJobs)
            {
                // 获取作业信息构建器
                var jobBuilder = schedulerBuilder.GetJobBuilder();

                // 加载数据库数据
                var dbDetail = await _jobRepository.FirstOrDefaultAsync(u => u.JobId == jobBuilder.JobId);
                if (dbDetail == null) continue;

                // 同步数据库数据
                jobBuilder.LoadFrom(dbDetail);

                // 遍历所有作业触发器
                foreach (var (_, triggerBuilder) in schedulerBuilder.GetEnumerable())
                {
                    // 加载数据库数据
                    var dbTrigger = await _triggerRepository.FirstOrDefaultAsync(u => u.JobId == jobBuilder.JobId && u.TriggerId == triggerBuilder.TriggerId);
                    if (dbTrigger == null) continue;

                    triggerBuilder.LoadFrom(dbTrigger)
                                  .Updated();   // 标记更新
                }

                // 标记更新
                schedulerBuilder.Updated();
            }

            return allJobs;
        }

        public async Task OnChangedAsync(PersistenceContext context)
        {
            var sql = context.ConvertToSQL("JobDetails");
        }

        public async Task<SchedulerBuilder> OnLoadingAsync(SchedulerBuilder builder, CancellationToken stoppingToken)
        {
            var newBuilder = SchedulerBuilder.Create<AutoRefreshStockEveryDay>(Triggers.Daily()); // 表示每秒执行
            newBuilder = SchedulerBuilder.Create<AutoCloseOrderEveryDay>(Triggers.DailyAt(23).SetRunOnStart(true));
            newBuilder = SchedulerBuilder.Create<TenantToCacheJob>(Triggers.Daily().SetRunOnStart(true));

            // 返回新的作业计划构建器并标记为新增
            return newBuilder.Appended();
        }

        public async Task OnTriggerChangedAsync(PersistenceTriggerContext context)
        {
            var sql = context.ConvertToSQL("JobTriggers");
        }

        public void Dispose()
        {
            _serviceScope?.Dispose();
        }

        public Task OnExecutionRecordAsync(TriggerTimeline timeline)
        {
            throw new NotImplementedException();
        }

        public Task OnExecutionRecordAsync(PersistenceExecutionRecordContext context)
        {
            throw new NotImplementedException();
        }
    }
}
