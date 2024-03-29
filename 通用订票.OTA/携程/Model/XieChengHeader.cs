using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Model
{
    public class XieChengHeader
    {
        public const string CreatePreOrder = "CreatePreOrder";
        public const string QueryOrder = "QueryOrder";
        public const string PayPreOrder = "PayPreOrder";
        public string accountId { get; set; }
        public string serviceName { get; set; }
        public string requestTime { get; set; }
        public string version { get; set; }
        public string sign { get; set; }
    }
}
