using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    [Comment("联票")]
    public class MultiTicket : IEntity,IEntityTypeBuilder<MultiTicket>
    {
        public int id { get; set; }
        [Comment("景区id")]
        public Guid exhibitionId { get; set; }
        [Comment("票号")]
        public string ticketNumber { get; set; }
        [Comment("总数")]
        public int totalCount { get; set; }
        [Comment("已使用数量")]
        public int usedCount { get; set; }
        [Comment("取消数量")]
        public int cancelCount { get; set; }

        public void Configure(EntityTypeBuilder<MultiTicket> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.HasIndex(a => a.ticketNumber);
            entityBuilder.Property(a => a.id).ValueGeneratedOnAdd();
        }
    }
}
