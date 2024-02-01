using Furion.DatabaseAccessor;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using 通用订票.Base.Entity;

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
