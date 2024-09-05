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
    public class MultiTicket : IEntity,IEntityTypeBuilder<MultiTicket>
    {
        public int id { get; set; }
        public Guid exhibitionId { get; set; }
        public string ticketNumber { get; set; }
        public int totalCount { get; set; }
        public int usedCount { get; set; }
        public int cancelCount { get; set; }

        public void Configure(EntityTypeBuilder<MultiTicket> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.HasIndex(a => a.ticketNumber);
            entityBuilder.Property(a => a.id).ValueGeneratedOnAdd();
        }
    }
}
