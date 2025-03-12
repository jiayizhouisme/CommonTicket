using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class EnterExistRecords : IEntity, IEntityTypeBuilder<EnterExistRecords>
    {
        public int id { get; set; }
        public long userid { get;set; }
        public UserInfo userinfo { get; set; }
        public DateTime recordTime { get; set; }
        public DeviceType type { get; set; }

        public void Configure(EntityTypeBuilder<EnterExistRecords> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);

            entityBuilder.Property(x => x.id).ValueGeneratedOnAdd();
            entityBuilder.HasOne(a => a.userinfo).WithMany().HasForeignKey(a => a.userid);
        }
    }
}
