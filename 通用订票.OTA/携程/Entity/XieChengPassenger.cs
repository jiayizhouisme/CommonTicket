using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Entity
{
    public class XieChengPassenger : IEntity, IEntityTypeBuilder<XieChengPassenger>
    {
        public string passengerId { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string gender { get; set; }
        public string nationalityName { get; set; }

        public void Configure(EntityTypeBuilder<XieChengPassenger> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.passengerId);
        }
    }
}
