using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.EventBus.Entity
{
    public class BaseEntity
    {
        public string tenantId { get; set; }
        public string userId { get; set; }
    }
}
