using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengCancelOrder
    {
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public int confirmType { get; set; }
        public int supplierConfirmType { get; set; }
        public string tenant_id { get; set; }
        public XieChengCancelOrderItems[] items { get; set; }
    }

    public struct XieChengCancelOrderItems
    {
        public string itemId { get; set; }
        public string PLU { get; set; }
        public string lastConfirmTime { get; set; }
        public int cancelType { get; set; }
        public int quantity { get; set; }
        public XieChengPassenger[] passengers { get; set; }

    }

    public struct XieChengCancelOrderResponse
    {
        public int supplierConfirmType { get; set; }
        public XieChengCancelOrderReponseItems[] items { get;set; }
    }

    public struct XieChengCancelOrderReponseItems
    {
        public string itemId { get; set; }
        public XieChengVouchers[] vouchers { get; set; }
    }

    public struct XieChengCancelOrderConfirm
    {
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public string confirmResultCode { get; set; }
        public string confirmResultMessage { get; set; }

        public int supplierConfirmType { get; set; }
        public List<XieChengCancelOrderReponseItems> items { get; set; }
    }
}
