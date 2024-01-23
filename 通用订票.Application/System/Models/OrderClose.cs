using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Models
{
    public class OrderClose
    {
        public string trade_no { get; set; }
        public Appointment app { get; set; }
        public ICollection<Core.Entity.Ticket> tickets { get;set; }
        public int delay{ get; set; }
        public string tenantId { get; set; }
        public string realTenantId { get; set; }
    }
}
