namespace 通用订票.Web.Entry.Model
{
    public struct AppointmentEasyModel
    {
        public DateTime date { get; set; }
        public decimal price { get; set; }
        public int salesLeft { get; set; }
        public bool available { get; set; }
        public CloseReason closeReason { get; set; }
    }

    public enum CloseReason
    {
        未开放,
        已约完,
        已结束
    }
}
