using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class Exhibition :IEntity,IEntitySeedData<Exhibition>
    {
        public Guid id { get; set; }
        public string name{ get;set;}
        public string description { get;set;}
        public string imgs { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createTime { get; set; }
        public decimal basicPrice { get; set; }

        public IEnumerable<Exhibition> HasData(DbContext dbContext, Type dbContextLocator)
        {
            List<Exhibition> list = new List<Exhibition>();
            for (int i = 0;i < 30;i ++)
            {
                list.Add(new Exhibition()
                {
                    id = Guid.NewGuid(),
                    name = "展馆" + i,
                    basicPrice = 10,
                    description = name,
                    createTime = DateTime.Now,
                    isDeleted = false,
                    status = 1,
                    imgs = null
                });
            }
            return list;
        }
    }
}
