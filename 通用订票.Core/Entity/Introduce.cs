using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public class Introduce : IEntity<MasterDbContextLocator>
    {
        [Key]
        public int id { get; set; }
        public string? exDescription { get; set; }
        public string? turDescription { get; set; }
        public string[] imgs { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<int> type { get; set; }
    }
}
