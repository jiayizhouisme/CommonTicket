using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using 通用订票.Order.Entity;

namespace 通用订票.Core.Entity
{
    public class XieChenOrder : OrderBase<Guid>,IEntity, IEntityTypeBuilder<XieChenOrder>
    {
        public DateTime? createTime { get; set; }

        public void Configure(EntityTypeBuilder<XieChenOrder> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.trade_no);

        }
    }
}

