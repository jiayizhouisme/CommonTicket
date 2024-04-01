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

namespace 通用订票.Application.System.Services.IService
{
    public interface IDefaultTicketService : IBaseService<Core.Entity.Ticket>,ITicketService<Core.Entity.Ticket>, IUserContext<Guid>
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
        public Task<List<Core.Entity.Ticket>> GenarateTickets(DateTime startTime, DateTime endTime, OrderBase<Guid> order, int[] uid, TicketStatus status,OTAType otaType = OTAType.Normal);
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
        public Task<Ticket> GenarateTickets(DateTime startTime, DateTime endTime, OrderBase<Guid> order, int number,TicketStatus status, OTAType otaType = OTAType.Normal);
        public Task<List<Ticket>> GenarateTickets(DateTime startTime, DateTime endTime, OrderBase<Guid> order, int number, string[] OTAPassengerId, TicketStatus status, OTAType otaType);
        public Task<bool> Vaild(int[] uid, Core.Entity.Appointment stock);
        public Task<ICollection<Core.Entity.Ticket>> GetTickets(long orderId);
        public Task<int> DisableTickets(ICollection<Core.Entity.Ticket> ticket);
        public Task<int> EnableTickets(ICollection<Core.Entity.Ticket> ticket);
    }
}
