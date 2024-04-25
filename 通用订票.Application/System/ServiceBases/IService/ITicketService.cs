using Core.Services;
using 通用订票.Application.System.Models;
using 通用订票.Base.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface ITicketService<T> : IBaseTicketService<T> where T : Core.Entity.Ticket, new()
    {
        Task AfterTicketToke(long objectId);
    }
}
