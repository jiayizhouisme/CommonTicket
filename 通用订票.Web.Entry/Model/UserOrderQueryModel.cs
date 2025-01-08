using Furion.DatabaseAccessor;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Web.Entry.Model
{
    public class UserOrderQueryModel
    {
        public UserOrderQueryModel(通用订票.Core.Entity.Order order)
        {
            amount = order.amount;
            count = order.count;
            trade_no = order.trade_no;
            exhibitionName = order.name;
            if (order.ticketStatus == TicketStatus.已使用 || order.ticketStatus == TicketStatus.部分使用)
            {
                this.status = Enum.GetName(typeof(TicketStatus), order.ticketStatus);
            }
            else if(order.ticketStatus == TicketStatus.未使用 && order.status == OrderStatus.已付款)
            {
                this.status = Enum.GetName(typeof(TicketStatus), order.ticketStatus);
            }
            else
            {
                this.status = Enum.GetName(typeof(OrderStatus),order.status);
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public long trade_no { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string exhibitionName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string status { get; set; }
    }
}
