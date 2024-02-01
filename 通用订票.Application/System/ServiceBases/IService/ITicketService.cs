using Core.Services;
using 通用订票.Base.IService;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface ITicketService<T> : IBaseTicketService<T>, IBaseService<T> where T : Core.Entity.Ticket, new()
    {
        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        bool TicketCheck(T ticket);
        Task AfterTicketToke(long objectId);
    }
}
