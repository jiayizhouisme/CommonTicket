using Core.Services;
using 通用订票.Base.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface ITicketService<T> : IBaseTicketService<T> where T : Core.Entity.Ticket, new()
    {
        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        Task<T> TicketCheck(T ticket, int useCount);
        Task AfterTicketToke(long objectId);
    }
}
