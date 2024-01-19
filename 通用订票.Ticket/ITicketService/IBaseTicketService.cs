using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Ticket.Entity;

namespace 通用订票.Ticket
{
    public interface IBaseTicketService<T> where T : TicketAbstract, new()
    {
        
        /// <summary>
        /// 生成订票
        /// </summary>
        /// <returns></returns>
        T GenerateTicket(DateTime startTime, DateTime endTime);

        Task<T> EnableTicket(T ticket);
        Task<T> DisableTicket(T ticket);
    }
}
