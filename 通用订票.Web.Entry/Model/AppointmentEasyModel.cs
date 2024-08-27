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
        展馆关闭,
        票已售空
    }
}
