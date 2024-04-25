using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IMultiTicketService : IBaseService<MultiTicket>
    {
        Task<ICollection<MultiTicket>> GenerateTicket(string ticket_number,string[] exhibitions,int totalCount);
        Task<MultiTicketCancelResult> CancelTicket(string ticket_number, int cancelCount);
        Task<TicketVerifyResult> CheckMultiTicket(string ticket_number, string exhibition);
        Task<MultiTicketVerifyResult> ConfirmCheckMultiTicket(string ticket_number, string exhibition);
    }
}
