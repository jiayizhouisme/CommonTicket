using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using Core.Services;
using 通用订票.Core.Entity;
using 通用订票.Ticket.Entity;
using Core.Auth;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public class TicketBaseService<T> : BaseService<T>, ITicketService<T> where T : Core.Entity.Ticket,new()
    {
        public TicketBaseService(IRepository<T> _dal)
        {
            base._dal = _dal;
        }

        /// <summary>
        /// 订单冻结
        /// </summary>
        /// <param name="ticket"></param>
        public async virtual Task<T> DisableTicket(T ticket)
        {
            if (ticket.stauts != TicketStatus.已使用)
            {
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
            if (ticket.stauts != TicketStatus.已使用)
            {
                ticket.isDeleted = false;
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
            ticket.id = Guid.NewGuid();
            ticket.isDeleted = false;
            ticket.stauts = TicketStatus.未激活;
            ticket.createTime = DateTime.Now;
            ticket.startTime = startTime;
            ticket.endTime = endTime;
            ticket.ticketNumber = Msectime() + Math.Abs(ticket.id.GetHashCode());
            return ticket;
        }

        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public virtual bool TicketCheck(T ticket)
        {
            if (DateTime.Now.CompareTo(ticket.startTime) >= 0 || DateTime.Now.CompareTo(ticket.startTime) < 0)
            {
                if (ticket.stauts == TicketStatus.未使用)
                {
                    return true;
                }
            }
            return false;
        }

        private string Msectime()
        {
            long timeTicks = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            return timeTicks.ToString();
        }

        public virtual async Task AfterTicketToke(Guid objectId)
        {

        }
    }
}
