using 通用订票.Base.Entity;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Model
{
    public class GetTicketsModel
    {
        public GetTicketsModel(通用订票.Core.Entity.Order order,Ticket ticket,Exhibition exhibition,Appointment app,UserInfo userinfo)
        {
            if (ticket != null)
            {
                startTime = ticket.startTime;
                endTime = ticket.endTime;
                status = Enum.GetName(typeof(TicketStatus), ticket.stauts);
            }

            if (exhibition != null)
            {
                exhibitionName = exhibition.name;
            }

            if (userinfo != null)
            {
                idCard = userinfo.idCard;
                phoneNumber = userinfo.phoneNumber;
                username = userinfo.name;
            }
            if (order != null)
            {
                appTime = order.createTime.Value;
            }
        }

        public string exhibitionName { get; set; }
        public string username { get; set; }
        public string idCard { get; set; }
        public string phoneNumber { get; set; }
        public DateTime appTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string status { get; set; }
        
    }
}
