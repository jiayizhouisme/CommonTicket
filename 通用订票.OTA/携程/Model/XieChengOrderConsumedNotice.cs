using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengOrderConsumedNotice
    {
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public XieChengOrderConsumedNoticeItem[] items { get; set; }

    }

    public struct XieChengOrderConsumedNoticeItem {
        public string itemId { get; set; }
        public string useStartDate { get; set; }
        public string useEndDate { get; set; }
        public int quantity { get; set; }
        public int useQuantity { get; set; }

        public XieChengPassenger[] passengers { get; set; }
        public XieChengVouchers[] vouchers { get; set; }
    }

}
