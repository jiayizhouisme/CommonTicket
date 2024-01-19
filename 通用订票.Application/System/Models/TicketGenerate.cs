using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Application.System.Models
{
    public class TicketGenerate
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Core.Entity.Order order { get; set; }
        public Guid[] uids { get; set; }
        public Guid userID { get; set; }
    }
}
