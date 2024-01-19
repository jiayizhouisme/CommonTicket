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
    public class Appointment : 通用订票.Core.BaseEntity.Stock, IEntityTypeBuilder<Appointment> ,IEntity
    {
        public int day { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string description { get; set; }
        public string brief { get; set; }
        public Guid objectId { get; set; }
        public Exhibition exhibition {get;set;}

        public void Configure(EntityTypeBuilder<Appointment> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.HasOne(a => a.exhibition).WithMany().HasForeignKey(a => a.objectId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
