using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Models
{
    public struct TicketVerifyEventModel
    {
        public OTAType type;
        public string ticketNumber;
        public int count;
        public string tenant_id;
    }
}
