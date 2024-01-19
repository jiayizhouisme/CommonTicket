using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.SignalR;

namespace 通用订票.Application.System.Models
{
    public class OrderCreateDone
    {
        public IHubContext<ChatHub> _hubContext { get; set; }
        public RealOnlineClient client { get; set; }
    }
}
