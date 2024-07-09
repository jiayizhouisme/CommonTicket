using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.RetValues
{
    public struct OpreationResult
    {
        public string name { get; set; }
        public string opreation1 { get; set; }
        public string opreation2 { get; set; }
        public string successed { get; set;  }
    }
    public static class RetValues
    {
        private static readonly string Create = "创建";
        private static readonly string Close = "关闭";
        private static readonly string Pay = "支付";
        private static readonly string Refund = "退款";

        private static readonly string Entity = "订单";

        public static OpreationResult CreateOrder = 
            new OpreationResult { opreation1 = "创建",name = "订单",opreation2 = "创建"};
        public static OpreationResult CloseOrder =
            new OpreationResult { name = "订单", opreation2 = "创建" };
        public static OpreationResult PayOrder =
            new OpreationResult { name = "订单", opreation2 = "创建" };
        public static OpreationResult RefundOrder =
            new OpreationResult { name = "订单", opreation2 = "创建" };
    }
}
