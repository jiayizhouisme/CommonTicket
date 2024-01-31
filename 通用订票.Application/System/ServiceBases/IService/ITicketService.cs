using Core.Services;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface ITicketService<T> : 通用订票.Ticket.IBaseTicketService<T>, IBaseService<T> where T : Core.Entity.Ticket, new()
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
