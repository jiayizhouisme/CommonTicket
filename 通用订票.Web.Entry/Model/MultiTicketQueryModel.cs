using 通用订票.Base.Entity;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Model
{

    public class TicketQueryModel
    {
        public string ticketNumber { get; set; }
        public string name { get; set; }
        public int totalCount { get; set; }
        public DateTime startTime { get; set; }
        public string qrCode { get; set; }
        public ICollection<MultiTicketQueryModel> mtickets { get; set; }
    }
    public class MultiTicketQueryModel
    {
        public MultiTicketQueryModel(MultiTicket mt)
        {
            if (mt.usedCount > 0)
            {
                this.status = Enum.GetName(typeof(TicketStatus), TicketStatus.已使用);
            }
            else
            {
                this.status = Enum.GetName(typeof(TicketStatus), TicketStatus.未使用);
            }
            this.exhibitionId = mt.exhibitionId;
        }
        public string exhibitionName { get; set; }
        public Guid exhibitionId { get; set; }
        public string status { get; set; }
    }
}
