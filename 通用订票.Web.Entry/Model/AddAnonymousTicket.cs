namespace 通用订票.Web.Entry.Model
{
    public class AddAnonymousTicket
    {
        public Guid exhibitionId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime{get; set; }
        public int totalCount { get; set; }
        public decimal amount { get; set; }
        public string username { get; set; }
        public string idcard { get; set; }
        public string phoneNumber { get; set; }
    }
}
