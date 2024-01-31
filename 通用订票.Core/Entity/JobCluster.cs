using Furion.DatabaseAccessor;
using System;
using System.ComponentModel.DataAnnotations;

namespace 通用订票.Core.Entity
{
    public class JobCluster : IEntity<MultiTenantDbContextLocator>
    {
        [Key]
        public int Id { get; set; }


       
        /// <summary>
        /// 描述信息
        /// </summary>
        public string? Description { get; set; }

        public ClusterStatus Status { get; set; }
        
        /// <summary>
        /// 作业更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }

    public enum ClusterStatus
    {
        Crashed,
        Working,
        Waiting
    }

}
