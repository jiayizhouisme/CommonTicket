using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public struct XiechengCreateOrder
    {
        public string tenant_id { get; set; }
        public string sequenceId { get; set; }
        public string otaOrderId { get; set; }
        public XieChengOrder[] items { get; set; }
        
    }
}
