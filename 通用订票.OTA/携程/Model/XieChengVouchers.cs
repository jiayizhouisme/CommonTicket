using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengVouchers
    {
        public string itemId { get; set; }
        public string voucherId { get;set; }
        public int voucherType { get; set;}
        public string voucherCode { get; set; }
        public string voucherData { get; set; }
        public string voucherSeatInfo { get; set; }
    }
}
