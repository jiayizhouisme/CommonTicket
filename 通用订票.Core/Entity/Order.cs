using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Order.Entity;

namespace 通用订票.Core.Entity
{
    public class Order : OrderBase<Guid>,IEntity, IEntityTypeBuilder<Order>
    {
        public int _id { get; set; }
        public Guid id { get; set; }
        public DateTime? createTime { get; set; }
        public bool isDeleted { get; set; }

        public void Configure(EntityTypeBuilder<Order> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a._id);
            entityBuilder.Property(x => x._id).ValueGeneratedOnAdd();
            entityBuilder.HasQueryFilter(a => a.isDeleted == false);
        }
    }
}

