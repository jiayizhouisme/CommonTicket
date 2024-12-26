using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitForm1._222222.Model
{
    public enum TicketStatus
    {
        未使用 = 0,
        部分使用,
        已使用,
        未激活,
        已冻结
    }
    public class Ticket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TUserId { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreateTime { get; set; }

        public UserInfos UserInfo { get; set; }
        
        public string UserInfoId { get; set; }
        public Appointment Appointment { get; set; }
     
    }
}
