using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Application.System.Models
{
    public class TicketCreate
    {
        public Guid userid { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Core.Entity.Order order { get; set; }
        public ICollection<Guid> uid { get; set; }
        public string tenantId { get; set; }
        public string realTenantId { get; set; }
    }
}
