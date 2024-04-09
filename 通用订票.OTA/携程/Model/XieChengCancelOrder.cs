using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public class XieChengCancelOrder : XieChengBodyBase
    {
        public string supplierOrderId { get; set; }
        public int confirmType { get; set; }
        public int supplierConfirmType { get; set; }
        public string tenant_id { get; set; }
        public XieChengCancelOrderItems[] items { get; set; }
    }

    public class XieChengCancelOrderItems : XieChengItem
    {
        public string lastConfirmTime { get; set; }
        public int cancelType { get; set; }
        public int quantity { get; set; }

    }

    public class XieChengCancelOrderResponse
    {
        public int supplierConfirmType { get; set; }
        public XieChengCancelOrderReponseItems[] items { get;set; }
    }

    public class XieChengCancelOrderReponseItems
    {
        public string itemId { get; set; }
        public XieChengVouchers[] vouchers { get; set; }
    }

    public class XieChengCancelOrderConfirm : XieChengBodyBase
    {
        public string supplierOrderId { get; set; }
        public string confirmResultCode { get; set; }
        public string confirmResultMessage { get; set; }

        public int supplierConfirmType { get; set; }
        public List<XieChengCancelOrderReponseItems> items { get; set; }
    }
}
