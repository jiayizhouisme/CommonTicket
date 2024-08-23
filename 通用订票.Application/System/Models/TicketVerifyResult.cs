using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Models
{
    public struct TicketVerifyResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public Ticket ticket { get; set; }
        public Exhibition exhibition { get; set; }
        public Appointment app { get; set; }
        public Core.Entity.Order order { get; set; }
        //是否上传到OTA，只有OTA会用到这个值
        public bool shouldUpdate { get; set; }
    }

    public struct MultiTicketVerifyResult
    {
        public int code { get; set; }
        public int usedCount { get; set; }
    }
}
