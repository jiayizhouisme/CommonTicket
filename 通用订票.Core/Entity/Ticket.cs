using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using 通用订票.Base.Entity;

namespace 通用订票.Core.Entity
{
    [Comment("门票")]
    public class Ticket : TicketBase<long>,IEntity,IEntityTypeBuilder<Ticket>
    {
        public int _id { get; set; }
        [Comment("创建时间")]
        public DateTime? createTime { get; set; }
        [Comment("时间段id")]
        public string AppointmentId { get; set; }
        [Comment("服务商类型")]
        public OTAType ota { get; set; }
        [Comment("票总数")]
        public int totalCount { get; set; }
        [Comment("已使用数量")]
        public int usedCount { get; set; }
        [Comment("无效票数量")]
        public int cancelCount { get; set; }
        [Comment("核销时间")]
        public DateTime? verifyTime { get; set; }
        [Comment("是否是联票")]
        public bool isMultiPart { get; set; }
        public string QRCode { get; set; }
        /// <summary>
        /// 购票人选择的用户
        /// </summary>
        public long TUserId { get; set; }

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
