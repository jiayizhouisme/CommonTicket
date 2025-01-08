using Furion.DatabaseAccessor;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Web.Entry.Model
{
    public class UserOrderDetailQueryModel : UserOrderQueryModel
    {
        public UserOrderDetailQueryModel(通用订票.Core.Entity.Order order) : base(order) { 
            this.payedTime = order.payedTime;
        }
        public string payedTime { get; set; }
        public ICollection<TicketQueryModel> tickets { get; set; }
    }
}
