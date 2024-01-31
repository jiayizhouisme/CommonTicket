using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace 通用订票.Core.Entity
{
    public class UserInfo : IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string idCard { get; set; }
        public DateTime createTime { get; set; }
        public Guid userID { get; set; }
        public User user { get; set; }

        public void Configure(EntityTypeBuilder<UserInfo> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.Property(x => x.id).ValueGeneratedOnAdd();
            entityBuilder.HasOne(a => a.user).WithMany().HasForeignKey(a => a.userID);
        }

      
    }
}
