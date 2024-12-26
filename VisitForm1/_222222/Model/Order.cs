using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitForm1._222222.Model
{

    public enum OrderStatus
    {
        未付款 = 0,
        已付款 = 1,
        已关闭 = 2,
        已退款 = 3,
        一部分退款 = 4,
        支付中 = 5,
        退款中 = 6
    }
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime?CreateTime { get; set; }

        public string? TradeNo { get; set; }
        public long ?UserId {  get; set; }
        public decimal? Amount { get; set; }
        public decimal ?PayedAmount { get; set; }
        public string? ObjectId { get; set; }
        public OrderStatus? Status {  get; set; }
        public TicketStatus UseStatus { get; set; }
        [ForeignKey("Appointment")]
        public Guid ?AppointmentId {  get; set; }
         public ICollection<Ticket> Tickets { get; set; }
      
        public virtual Appointment Appointment { get; set; }

        
    }

}
