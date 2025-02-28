namespace 通用订票.Web.Entry.Model
{
    public class CreateAnonymousReturn
    {
        public string ticketNumber { get; set; }
        public string exhibitionName { get; set; }
        public string username { get; set; }
        public decimal amount { get; set; }
        public string qrcode { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime? createTime { get; set; }
    }
}
