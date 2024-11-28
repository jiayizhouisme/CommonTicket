using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitForm1._222222.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string TradeNo { get; set; }
        public int ObjectId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
