using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IWechatPayService
    {
        /// <summary>
        ///     发起支付
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        Task<WechatBill> PubPay(WechatBill entity, WechatMerchantConfig config, string openid);


        /// <summary>
        ///     用户退款
        /// </summary>
        /// <param name="refundInfo">退款单数据</param>
        /// <param name="paymentInfo">支付单数据</param>
        /// <returns></returns>
        Task<WechatBillRefund> Refund(WechatBillRefund refundInfo, WechatBill entity, WechatMerchantConfig config);
    }
}
