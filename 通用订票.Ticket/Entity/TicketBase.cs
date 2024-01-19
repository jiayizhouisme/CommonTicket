using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Ticket.Entity
{
    public abstract class TicketBase<T> : TicketAbstract
    {
        /// <summary>
        /// 门票持有人ID
        /// </summary>
        public T userID { get; set; }
        /// <summary>
        /// 门票关联字段
        /// </summary>
        public T? objectId { get; set; }
    }
}
