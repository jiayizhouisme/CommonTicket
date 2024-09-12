using Core.Services;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Base.Entity;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public class TicketBaseService<T,DbLocator> : BaseService<T, DbLocator>, ITicketService<T> where T : Core.Entity.Ticket,new() where DbLocator : class, IDbContextLocator
    {
        public TicketBaseService(IRepository<T, DbLocator> _dal)
        {
            base._dal = _dal;
        }

        /// <summary>
        /// 订单冻结
        /// </summary>
        /// <param name="ticket"></param>
        public async virtual Task<T> DisableTicket(T ticket)
        {
            if (ticket.stauts != TicketStatus.已使用 && ticket.stauts != TicketStatus.部分使用)
            {
                ticket.cancelCount = ticket.totalCount - ticket.usedCount;
                ticket.stauts = TicketStatus.已冻结;
            }
            return ticket;
        }

        /// <summary>
        /// 激活订单
        /// </summary>
        /// <param name="ticket"></param>
        public async virtual Task<T> EnableTicket(T ticket)
        {
            if (ticket.stauts != TicketStatus.已使用 && ticket.stauts != TicketStatus.部分使用)
            {
                ticket.stauts = TicketStatus.未使用;
            }
            
            return ticket;
        }

        /// <summary>
        /// 生成一张空票
        /// </summary>
        /// <returns></returns>
        public virtual T GenerateTicket(DateTime startTime, DateTime endTime)
        {
            Random rand = new Random();
            T ticket = new T();
            ticket.stauts = TicketStatus.未激活;
            ticket.createTime = DateTime.Now;
            ticket.startTime = startTime;
            ticket.endTime = endTime;
            ticket.ticketNumber = Msectime() + Math.Abs(Guid.NewGuid().GetHashCode());
            return ticket;
        }

        private string Msectime()
        {
            long timeTicks = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            return timeTicks.ToString();
        }

        public virtual async Task AfterTicketToke(long objectId)
        {

        }
    }
}
