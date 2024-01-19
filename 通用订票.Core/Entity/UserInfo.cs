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
    public class UserInfo : IEntity, IEntitySeedData<UserInfo>,IEntityTypeBuilder<UserInfo>
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string idCard { get; set; }
        public DateTime createTime { get; set; }
        public bool isDeleted { get; set; }
        public Guid userID { get; set; }
        public User user { get; set; }

        public void Configure(EntityTypeBuilder<UserInfo> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
            entityBuilder.HasOne(a => a.user).WithMany().HasForeignKey(a => a.userID);
            entityBuilder.HasQueryFilter(a => a.isDeleted == false);
        }

        public IEnumerable<UserInfo> HasData(DbContext dbContext, Type dbContextLocator)
        {
            //List<UserInfo> users = new List<UserInfo>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    users.Add(new UserInfo()
            //    {
            //        id = Guid.NewGuid(),
            //        isDeleted = false,
            //        name = "user_" + i,
            //        userID = Guid.Parse("43751D17-E26B-4E1E-AB25-2673B39DF3FC")
            //    });
            //}
            //for (int i = 0; i < 100; i++)
            //{
            //    users.Add(new UserInfo()
            //    {
            //        id = Guid.NewGuid(),
            //        isDeleted = false,
            //        name = "SupserUser_" + i,
            //        userID = Guid.Parse("43751D17-E26B-4E1E-AB25-2673B39DF3FC")
            //    }); ;
            //}
            //return users;
            return null;
        }
    }
}
