using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public struct XieChengTIcketVerifyResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public XieChengTicket ticket { get; set; }
    }
}
