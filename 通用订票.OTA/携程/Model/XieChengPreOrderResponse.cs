namespace 通用订票.OTA.携程.Model
{
    public class XieChengPreOrderResponse
    {
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public List<XieChengItem> items { get; set; }
    }
}