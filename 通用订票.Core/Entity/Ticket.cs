using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using 通用订票.Base.Entity;

namespace 通用订票.Core.Entity
{
    public class Ticket : TicketBase<string>,IEntity,IEntityTypeBuilder<Ticket>
    {
        public int _id { get; set; }
        public DateTime? createTime { get; set; }
        public string AppointmentId { get; set; }
        public OTAType ota { get; set; }
        public int totalCount { get; set; }
        public int usedCount { get; set; }
        public int cancelCount { get; set; }
        public DateTime? verifyTime { get; set; }
        public bool isMultiPart { get; set; }
        /// <summary>
        /// 购票人选择的用户
        /// </summary>
        public int TUserId { get; set; }

        public void Configure(EntityTypeBuilder<Ticket> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a._id );

            entityBuilder.HasIndex(a => new {a.TUserId,a.startTime,a.endTime});
            entityBuilder.HasIndex(a => a.objectId);

            entityBuilder.Property(x => x._id).ValueGeneratedOnAdd();
        }
    }

    public enum OTAType
    {
        Normal,
        XieCheng,
        TongCheng,
        MeiTuan
    }
}
