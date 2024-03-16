using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using 通用订票.Order.Entity;

namespace 通用订票.OTA.Entity
{
    public class XieChengOrder : OrderBase<string>,IEntity, IEntityTypeBuilder<XieChengOrder>
    {
        public DateTime? createTime { get; set; }

        public void Configure(EntityTypeBuilder<XieChengOrder> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.trade_no);

        }
    }
}

