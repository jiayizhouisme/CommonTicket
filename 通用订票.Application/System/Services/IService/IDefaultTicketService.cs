using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using Core.Auth;
using 通用订票.Core.Entity;
using 通用订票.Core.BaseEntity;
using 通用订票.Base.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IDefaultTicketService : ITicketService<Core.Entity.Ticket>, IUserContext<Guid>
    {
        public Task<List<Core.Entity.Ticket>> GenarateTickets(DateTime startTime, DateTime endTime, Core.Entity.Order order, int[] uid, TicketStatus status);
        public Task<bool> Vaild(int[] uid, Core.Entity.Appointment stock);
        public Task<ICollection<Core.Entity.Ticket>> GetTickets(long orderId);
        public Task<int> DisableTickets(ICollection<Core.Entity.Ticket> ticket);
        public Task<int> EnableTickets(ICollection<Core.Entity.Ticket> ticket);
    }
}
