using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitForm1._222222.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string TradeNo { get; set; }
        public string UserId {  get; set; }
        public decimal Amount { get; set; }
        public decimal PayedAmount { get; set; }
        public int ObjectId { get; set; }
        public int Status {  get; set; }
        public string AppointmentId {  get; set; }
        public ICollection<Ticket> Tickets { get; set; }
       
        public virtual Appointment Appointment { get; set; }
    }
}
