using Core.User.Entity;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class User : UserBase,IEntity, IEntitySeedData<User>
    {
        public Guid id { get; set; }

        public int authLevel { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreateTime { get; set; }

        public IEnumerable<User> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return null;
            //List<User> users = new List<User>();
            //for (int i = 0;i < 1000;i++)
            //{
            //    users.Add(new User() { id = Guid.NewGuid(), isDeleted = false, CreateTime = DateTime.Now, 
            //        username = "user_" + i, password = "1233211234567",authLevel = 0 });
            //}
            //for (int i = 0; i < 100; i++)
            //{
            //    users.Add(new User()
            //    {
            //        id = Guid.NewGuid(),
            //        isDeleted = false,
            //        CreateTime = DateTime.Now,
            //        username = "SupserUser_" + i,
            //        password = "1233211234567",
            //        authLevel = 1
            //    }); ;
            //}
            //return users;
        }
    }
}
