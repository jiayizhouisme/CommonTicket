using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Models
{
    public struct MultiTicketCancelResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public bool shouldUpdate {  get; set; }
    }

}
