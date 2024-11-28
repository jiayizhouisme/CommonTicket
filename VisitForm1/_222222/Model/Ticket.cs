using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitForm1._222222.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TUserId { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreateTime { get; set; }

        public UserInfo UserInfo { get; set; }
        public ICollection<UserInfo> UserInfos { get; set; }
        public string UserInfoId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
