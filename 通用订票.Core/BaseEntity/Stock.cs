using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Stock.Entity;

namespace 通用订票.Core.BaseEntity
{
    [NotMapped]
    public class Stock : StockAbstract,IEntity
    {
        public Guid id { get; set; }
        public DateTime? createTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
