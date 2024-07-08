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
        private static object _NULL = new { };
        private static string _NULLSTR = "";
        public OpreationResult()
        {
            this.data = _NULL;
            data = _NULLSTR;
        }
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public string detail { get; set; }

    }
    public static class RetValues
    {
        
        
        public static OpreationResult Ok(object data = null,string detail = null)
        {
            return CreateOrderSuccessed;
        }

        private static OpreationResult CreateOrderSuccessed = 
            new OpreationResult { code = 200,message = "订单创建成功"};
        private static OpreationResult CreateOrderFailed  = 
            new OpreationResult { code = 200, message = "订单创建失败" };
        private static OpreationResult CloseOrderSuccessed = 
            new OpreationResult { code = 200, message = "订单关闭成功" };
        private static OpreationResult CloseOrderFailed = 
            new OpreationResult { code = 200, message = "订单关闭失败" };
        private static OpreationResult PayOrderSuccessed =
            new OpreationResult { code = 200, message = "订单支付成功" };
        private static OpreationResult PayOrderOrderFailed =
            new OpreationResult { code = 200, message = "订单支付失败" };
        private static OpreationResult RefundOrderSuccessed =
            new OpreationResult { code = 200, message = "订单退款成功" };
        private static OpreationResult RefundOrderFailed =
            new OpreationResult { code = 200, message = "订单退款失败" };
    }
}
