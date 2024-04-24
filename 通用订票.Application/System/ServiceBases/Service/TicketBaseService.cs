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

        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public virtual async Task<TicketVerifyResult> TicketCheck(T ticket,int useCount)
        {
            TicketVerifyResult tv = new TicketVerifyResult();
            if (ticket == null)
            {
                tv.code = 0;
                tv.message = "未找到门票";
                return tv;
            }
            var now = DateTime.Now;
            int couldUse = 0;
            if (useCount <= 0)
            {
                useCount = couldUse = ticket.totalCount - ticket.usedCount - ticket.cancelCount;
            }
            else
            {
                couldUse = ticket.totalCount - ticket.usedCount - ticket.cancelCount - useCount;
            }
            tv.ticket = ticket;
            if (couldUse < 0)
            {
                tv.code = 0;
                tv.message = "门票已被使用";
                return tv;
            }

            if (ticket.stauts != TicketStatus.未使用 && ticket.stauts != TicketStatus.部分使用)
            {
                tv.code = 0;
                tv.message = "门票未激活";
                return tv;
            }

            if (now.CompareTo(ticket.startTime) < 0)
            {
                tv.code = 0;
                tv.message = "门票未到使用时间";
                return tv;
            }

            if (now.CompareTo(ticket.endTime) >= 0)
            {
                tv.code = 0;
                tv.message = "门票已过期";
                return tv;
            }

            ticket.usedCount += useCount;
            if (ticket.usedCount == ticket.totalCount)
            {
                ticket.stauts = TicketStatus.已使用;
            }
            else
            {
                ticket.stauts = TicketStatus.部分使用;
            }
            ticket.verifyTime = now;
            tv.code = 1;
            tv.message = "门票校验成功";
            return tv;
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
