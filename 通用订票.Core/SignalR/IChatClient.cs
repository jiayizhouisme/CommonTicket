using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.SignalR
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
