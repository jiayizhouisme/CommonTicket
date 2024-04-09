using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public class XieChengPayPreConfirm
    {
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public string supplierOrderId { get; set; }
        public int supplierConfirmType { get; set; }
        public int confirmResultCode { get; set; }   
        public string confirmResultMessage { get; set; }
        public int voucherSender { get; set; }
        public XieChengVouchers[] vouchers { get; set; }
        public XieChengPayPreConfirmItems[] items { get; set; }
    }
}
