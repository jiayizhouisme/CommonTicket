using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.OTA.携程.Entity;

namespace 通用订票.OTA.携程.Model
{
    public class XiechengPayPreOrder : XieChengBodyBase
    {
        public string supplierOrderId { get; set; } 
        public int confirmType { get; set; }
        public string tenant_id { get; set; }
        public XieChengItem[] items { get; set; }
    }
}
