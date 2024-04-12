using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public class XieChengTicketConsumeRequest
    {
        public XieChengRequest request { get; set; }
        public XieChengOrderConsumedNotice raw { get; set; }
    }
}
