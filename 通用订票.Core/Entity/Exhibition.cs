using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class Exhibition :IEntity
    {
        public Guid id { get; set; }
        public string name{ get;set;}
        public string description { get;set;}
        public string imgs { get; set; }
        public int status { get; set; }
        public int isDeleted { get; set; }
        public DateTime createTime { get; set; }
        public decimal basicPrice { get; set; }
        
    }
}
