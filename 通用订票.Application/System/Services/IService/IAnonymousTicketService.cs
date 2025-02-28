using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IAnonymousTicketService : IDefaultTicketService
    {
        public Task<Ticket> GenarateAnonymousTickets(Guid exhibitionId,
            DateTime startTime,
            DateTime endTime,
            long TUserId,
            int totalCount = 1,
            string[] exhibitions = null,
            TicketStatus status = TicketStatus.未使用);
    }
}
