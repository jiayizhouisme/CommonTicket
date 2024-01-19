using Furion.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;

namespace 通用订票.Core.Entity
{
    public class JobTrigger:IEntity<MultiTenantDbContextLocator>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 作业触发器 Id
        /// </summary>
        public string TriggerId { get; set; }

        /// <summary>
        /// 作业 Id
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// 作业触发器类型
        /// </summary>
        /// <remarks>存储的是类型的 FullName</remarks>
        public string? TriggerType { get; set; }

        /// <summary>
        /// 作业触发器类型所在程序集
        /// </summary>
        /// <remarks>存储的是程序集 Name</remarks>
        public string? AssemblyName { get; set; }

        /// <summary>
        /// 作业触发器参数
        /// </summary>
        /// <remarks>运行时将反序列化为 object[] 类型并作为构造函数参数</remarks>
        public string? Args { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 作业触发器状态
        /// </summary>
        public TriggerStatus Status { get; set; } = TriggerStatus.Ready;

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 最近运行时间
        /// </summary>
        public DateTime? LastRunTime { get; set; }

        /// <summary>
        /// 下一次运行时间
        /// </summary>
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// 触发次数
        /// </summary>
        public long NumberOfRuns { get; set; }

        /// <summary>
        /// 最大触发次数
        /// </summary>
        /// <remarks>
        /// <para>0：不限制</para>
        /// <para>n：N 次</para>
        /// </remarks>
        public long MaxNumberOfRuns { get; set; }

        /// <summary>
        /// 出错次数
        /// </summary>
        public long NumberOfErrors { get; set; }

        /// <summary>
        /// 最大出错次数
        /// </summary>
        /// <remarks>
        /// <para>0：不限制</para>
        /// <para>n：N 次</para>
        /// </remarks>
        public long MaxNumberOfErrors { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public int NumRetries { get; set; } = 0;

        /// <summary>
        /// 重试间隔时间
        /// </summary>
        /// <remarks>默认1000毫秒</remarks>
        public int RetryTimeout { get; set; } = 1000;

        /// <summary>
        /// 是否立即启动
        /// </summary>
        public bool StartNow { get; set; } = true;

        /// <summary>
        /// 是否启动时执行一次
        /// </summary>
        public bool RunOnStart { get; set; } = false;

        /// <summary>
        /// 是否在启动时重置最大触发次数等于一次的作业
        /// </summary>
        /// <remarks>解决因持久化数据已完成一次触发但启动时不再执行的问题</remarks>
        public bool ResetOnlyOnce { get; set; } = true;

        /// <summary>
        /// 本次执行结果
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// 本次执行耗时
        /// </summary>
        public long ElapsedTime { get; set; }

        /// <summary>
        /// 作业触发器更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}
