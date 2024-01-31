using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using 通用订票.Order.Entity;

namespace 通用订票.Core.Entity
{
    public class Order : OrderBase<Guid>,IEntity, IEntityTypeBuilder<Order>
    {
        public int _id { get; set; }
        public DateTime? createTime { get; set; }

        public void Configure(EntityTypeBuilder<Order> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a._id);
            entityBuilder.HasIndex(a => a.trade_no);

            entityBuilder.Property(x => x._id).ValueGeneratedOnAdd();
        }
    }
}

