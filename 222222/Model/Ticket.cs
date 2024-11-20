using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace _222222.Model
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
        public String UserInfoId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
