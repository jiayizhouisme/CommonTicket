using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengOrderQuery
    {
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
    }
    public struct XieChengOrderQueryResponseWithHeader
    {
        public XieChengResponseHeader header { get; set; }
        public XieChengOrderQueryResponse body { get; set; }
    }
    public struct XieChengOrderQueryResponse
    {
        public XieChengOrderQueryResponse()
        {
            this.items = new List<XieChengOrderQueryResponseItems>();
        }
        public string supplierOrderId { get; set; }
        public string otaOrderId { get; set; }
        public List<XieChengOrderQueryResponseItems> items { get; set; }
    }

    public struct XieChengOrderQueryResponseItems
    {
        public XieChengOrderQueryResponseItems()
        {
            passengers = new List<XieChengOrderQueryPassengers>();
            vouchers = new List<XieChengOrderQueryVouchers>();
        }
        public string itemId { get; set; }
        public string useStartDate { get; set; }
        public string useEndDate { get; set; }
        public XieChengOrderStatus orderStatus { get; set; }
        public int quantity { get; set; }
        public int useQuantity { get; set;}
        public int cancelQuantity { get;set; }
        public List<XieChengOrderQueryPassengers> passengers { get; set; }
        public List<XieChengOrderQueryVouchers> vouchers { get; set; }
    }
    public struct XieChengOrderQueryPassengers
    {
        public string passengerId { get; set; }
        public int passengerStatus { get; set; }
    }

    public struct XieChengOrderQueryVouchers
    {
        public string voucherId { get; set; }
        public int voucherStatus { get; set; }
    }
}
