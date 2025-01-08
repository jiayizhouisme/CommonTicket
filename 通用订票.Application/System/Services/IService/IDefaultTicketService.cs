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
using Core.Services;
using 通用订票.Order.Entity;
using 通用订票.Application.System.Models;

namespace 通用订票.Application.System.Services.IService
{
    public interface IDefaultTicketService : IBaseService<Core.Entity.Ticket>,ITicketService<Core.Entity.Ticket>, IUserContext<long>
    {
        /// <summary>
        /// 记名购买
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="order"></param>
        /// <param name="uid"></param>
        /// <param name="status"></param>
        /// <param name="otaType"></param>
        /// <returns></returns>
        Task<List<Core.Entity.Ticket>> GenarateTickets(Guid exhibitionId,DateTime startTime, DateTime endTime, OrderBase<long> order, long[] uid, string[] exhibitions,TicketStatus status,OTAType otaType = OTAType.Normal);
        /// <summary>
        /// 匿名购买
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="order"></param>
        /// <param name="number"></param>
        /// <param name="status"></param>
        /// <param name="otaType"></param>
        /// <returns></returns>
        Task<Ticket> GenarateTicket(Guid exhibitionId,DateTime startTime, DateTime endTime, OrderBase<long> order, int number,TicketStatus status, string[] exhibitions = null,OTAType otaType = OTAType.Normal);
        Task<List<Ticket>> GenarateTickets(Guid exhibitionId,DateTime startTime, DateTime endTime, OrderBase<long> order, int number,TicketStatus status, string[] exhibitions = null,OTAType otaType = OTAType.Normal);
        Task<bool> Vaild(int[] uid, Core.Entity.Appointment stock);
        Task<ICollection<Core.Entity.Ticket>> GetTickets(long orderId);
        Task<Ticket> GetTicket(string ticket_number);
        Task<TicketVerifyResult> TicketBeginCheck(string ticket_number,int useCount, string exhibition = null);
        Task TicketEndCheck(Ticket ticket);
        Task<TicketVerifyResult> TicketCheck(Ticket ticket, int useCount,string exhibitionId);
        Task<int> DisableTickets(ICollection<Core.Entity.Ticket> ticket);
        Task<int> EnableTickets(ICollection<Core.Entity.Ticket> ticket);
        Task<MultiTicketCancelResult> CancelMultiTicket(string ticket_number,int cancelCount);
    }
}
