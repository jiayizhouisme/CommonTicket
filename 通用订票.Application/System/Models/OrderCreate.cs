using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Application.System.Models
{
    public class BaseOrderCreate {
        public Guid appid { get; set; }
        public ICollection<int> ids { get; set; }
    }


    public class OrderCreate : BaseOrderCreate
    {
        public Guid userid { get; set; }
        public string tenantId { get; set; }
        public string realTenantId { get; set; }
        public decimal price { get; set; }
        
    }
}
