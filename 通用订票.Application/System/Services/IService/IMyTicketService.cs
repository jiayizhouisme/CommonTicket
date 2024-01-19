using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using Core.Auth;

namespace 通用订票.Application.System.Services.IService
{
    public interface IMyTicketService : ITicketService<Core.Entity.Ticket>,IUserContext<Guid>
    {
        public Task<List<Core.Entity.Ticket>> GenarateTickets(DateTime startTime, DateTime endTime,Core.Entity.Order order,Guid[] uid);
        public Task<bool> Vaild(Guid[] uid,Guid appointmentId);
        public Task<List<Core.Entity.Ticket>> GetTickets(Guid orderId);
        public Task<int> DisableTickets(ICollection<Core.Entity.Ticket> ticket);
        public Task<int> EnableTickets(ICollection<Core.Entity.Ticket> ticket);
    }
}
