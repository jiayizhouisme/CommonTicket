using 通用订票.OTA.携程.Model;

namespace 通用订票.Web.Entry.Controllers
{
    public class XieChengPayPre
    {
        public int voucherSender { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public int supplierConfirmType { get; set; }
        public List<XieChengPayPreConfirmItems> items { get; set; }
    }
}