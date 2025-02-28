using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Model
{
    public class GetAnonymousTicketReturn
    {
        public string ticketNumber { get; set; }
        public Guid exhibitionId { get; set; }
        public string idCard { get;set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public decimal? amount { get; set; }
        public string qrcode { get; set; }
        public int totalCount { get; set; }
        public int usedCount { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime? createTime { get; set; }
    }
}
