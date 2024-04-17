using Core.User.Entity;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace 通用订票.Core.Entity
{
    public class User : UserBase,IEntity, IEntitySeedData<User>
    {
        public string id { get; set; }

        public int authLevel { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreateTime { get; set; }

        public IEnumerable<User> HasData(DbContext dbContext, Type dbContextLocator)
        {
            //List<User> users = new List<User>();
            //users.Add(new User()
            //{
            //    id = Guid.Parse("43751D17-E26B-4E1E-AB25-2673B39DF3FC"),
            //    isDeleted = false,
            //    authLevel = 1,
            //    CreateTime = DateTime.Now,
            //    password = "afdd0b4ad2ec172c586e2150770fbf9e",
            //    username = "admin"

            //});
            //return users;
            return null;
        }
    }
}
