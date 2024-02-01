using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using 通用订票.Core.Entity;

namespace 通用订票.JobTask
{
    public class JobClusterServer : IJobClusterServer
    {
        private readonly IServiceScope _serviceScope;
        private readonly IRepository<JobCluster,MultiTenantDbContextLocator> _jobClusterRepository;
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly ICacheOperation _cache;

        public JobClusterServer(IServiceScopeFactory serviceScope, ISchedulerFactory _schedulerFactory, ICacheOperation _cache)
        {
            this._schedulerFactory = _schedulerFactory;
            this._cache = _cache;

            _serviceScope = serviceScope.CreateScope();
            var services = _serviceScope.ServiceProvider;

            _jobClusterRepository = Db.GetRepository<JobCluster,MultiTenantDbContextLocator>(services);

        }
        /// <summary>
        /// 当前作业调度器启动通知
        /// </summary>
        /// <param name="context">作业集群服务上下文</param>
        public void Start(JobClusterContext context)
        {
            if (!_jobClusterRepository.Any(u => u.Id == int.Parse(context.ClusterId)))
            {
                _jobClusterRepository.InsertNow(new JobCluster() 
                {
                    Status = Core.Entity.ClusterStatus.Waiting,
                    Id = int.Parse(context.ClusterId),
                    UpdatedTime = DateTime.Now,
                });
            }
            else
            {
                var item = _jobClusterRepository.Where(a => a.Id == int.Parse(context.ClusterId)).FirstOrDefault();
                item.Status = Core.Entity.ClusterStatus.Waiting;
                item.UpdatedTime = DateTime.Now;
                _jobClusterRepository.UpdateNow(item);
            }
            // 在作业集群表中，如果 clusterId 不存在，则新增一条（否则更新一条），并设置 status 为 ClusterStatus.Waiting
        }

        /// <summary>
        /// 等待被唤醒
        /// </summary>
        /// <param name="context">作业集群服务上下文</param>
        /// <returns><see cref="Task"/></returns>
        public async Task WaitingForAsync(JobClusterContext context)
        {
            var clusterId = int.Parse(context.ClusterId);
            string lockerId = Guid.NewGuid().ToString();
            while (true)
            {
                try
                {
                    // 在这里查询数据库，根据以下两种情况处理
                    // 1) 如果作业集群表已有 status 为 ClusterStatus.Working 则继续循环
                    // 2) 如果作业集群表中还没有其他服务或只有自己，则插入一条集群服务或调用 await WorkNowAsync(clusterId); 之后 return;
                    // 3) 如果作业集群表中没有 status 为 ClusterStatus.Working 的，调用 await WorkNowAsync(clusterId); 之后 return;
                    await _cache.Lock("JobLock", lockerId);
                    if (_jobClusterRepository.Count() == 1 && _jobClusterRepository.Any(a => a.Id == clusterId))
                    {
                        await WorkNowAsync(clusterId);
                        break;
                    }

                    if (_jobClusterRepository.Any(a => a.Status == Core.Entity.ClusterStatus.Working))
                    {
                        await _cache.ReleaseLock("JobLock", lockerId);
                        await Task.Delay(30000);
                        continue;
                    }

                    if (_jobClusterRepository.All(a => a.Status != Core.Entity.ClusterStatus.Working))
                    {
                        await WorkNowAsync(clusterId);
                        break;
                    }
                }
                catch { 
                
                }
            }
            await _cache.ReleaseLock("JobLock", lockerId);
            return;
        }

        /// <summary>
        /// 当前作业调度器停止通知
        /// </summary>
        /// <param name="context">作业集群服务上下文</param>
        public void Stop(JobClusterContext context)
        {
            // 在作业集群表中，更新 clusterId 的 status 为 ClusterStatus.Crashed
            var item = _jobClusterRepository.Where(a => a.Id == int.Parse(context.ClusterId)).FirstOrDefault();
            item.Status = Core.Entity.ClusterStatus.Crashed;
            item.UpdatedTime = DateTime.Now;
            _jobClusterRepository.UpdateNow(item);

        }

        /// <summary>
        /// 当前作业调度器宕机
        /// </summary>
        /// <param name="context">作业集群服务上下文</param>
        public void Crash(JobClusterContext context)
        {
            // 在作业集群表中，更新 clusterId 的 status 为 ClusterStatus.Crashed
            var item = _jobClusterRepository.Where(a => a.Id == int.Parse(context.ClusterId)).FirstOrDefault();
            item.Status = Core.Entity.ClusterStatus.Crashed;
            item.UpdatedTime = DateTime.Now;
            _jobClusterRepository.UpdateNow(item);
        }

        /// <summary>
        /// 指示集群可以工作
        /// </summary>
        /// <param name="clusterId">集群 Id</param>
        /// <returns></returns>
        private async Task WorkNowAsync(int clusterId)
        {
            // 在作业集群表中，更新 clusterId 的 status 为 ClusterStatus.Working
            var item = await _jobClusterRepository.Where(a => a.Id == clusterId).FirstOrDefaultAsync();
            item.Status = Core.Entity.ClusterStatus.Working;
            item.UpdatedTime = DateTime.Now;
            await _jobClusterRepository.UpdateNowAsync(item);

            _schedulerFactory.AddJob<AutoRefreshStockEveryDay>(Triggers.Daily()); // 表示每天执行
            _schedulerFactory.AddJob<AutoCloseOrderEveryDay>(Triggers.DailyAt(23).SetRunOnStart(true));

        }
    }
}
