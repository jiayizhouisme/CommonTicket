using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;

namespace 通用订票.EventBus.Entity
{
    public class BeforeCreateOrder : BaseEntity
    {
        public Guid appid { get; set; }
        public ICollection<int> ids { get; set; }
        public string tenantId { get; set; }
        public decimal price { get; set; }
        public int count => ids.Count;
    }
}
