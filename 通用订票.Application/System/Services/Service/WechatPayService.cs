using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Request;
using Newtonsoft.Json;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatPayService : IWechatPayService,ISingleton
    {
        private readonly IWeChatPayClient _client;

        public WechatPayService(IWeChatPayClient _client)
        {
            this._client = _client;
        }
        public async Task<WechatBill> PubPay(WechatBill entity,WechatMerchantConfig config,string openid)
        {
            WeChatPayOptions _wechatpay = config.Adapt<WeChatPayOptions>();

            var billattach = JsonConvert.DeserializeObject<WechatBillAttach>(entity.Attach);

            var weChatPayUrl = "https://ticket.z2ww.com/" + billattach.tenant_id + "/api/payNotify/Unifiedorder";
            if (string.IsNullOrEmpty(weChatPayUrl))
            {
                return null;
            }

            var tradeType = "JSAPI";

            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = entity.payTitle.Length > 50 ? entity.payTitle[..50] : entity.payTitle,
                OutTradeNo = entity.paymentId.ToString(),
                TotalFee = Convert.ToInt32(entity.money * 100),
                SpBillCreateIp = entity.ip,
                NotifyUrl = weChatPayUrl,
                TradeType = tradeType,
                OpenId = openid,
                Attach = entity.Attach
            };

            var response = await _client.ExecuteAsync(request, _wechatpay);
            if (response.ReturnCode == WeChatPayCode.Success && response.ResultCode == WeChatPayCode.Success)
            {
                var req = new WeChatPayJsApiSdkRequest
                {
                    Package = "prepay_id=" + response.PrepayId
                };

                var parameter = await _client.ExecuteAsync(req, _wechatpay);
                // 将参数(parameter)给 公众号前端 让他在微信内H5调起支付(https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_7&index=6)
                parameter.Add("paymentId", entity.tradeNo);
                entity.parameters = parameter.ToJson();
                return entity;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     用户退款
        /// </summary>
        /// <param name="refundInfo">退款单数据</param>
        /// <param name="paymentInfo">支付单数据</param>
        /// <returns></returns>
        public async Task<WechatBillRefund> Refund(WechatBillRefund refundInfo, WechatBill entity, WechatMerchantConfig config)
        {

            var weChatRefundUrl = "";
            WeChatPayOptions _wechatpay = config.Adapt<WeChatPayOptions>();
            var request = new WeChatPayRefundRequest
            {
                OutRefundNo = refundInfo.refundId.ToString(),
                TransactionId = entity.tradeNo.ToString(),
                OutTradeNo = entity.paymentId.ToString(),
                TotalFee = Convert.ToInt32(entity.money * 100),
                RefundFee = Convert.ToInt32(refundInfo.money * 100),
                NotifyUrl = weChatRefundUrl
            };
            var response = await _client.ExecuteAsync(request, _wechatpay);

            if (response.ReturnCode == WeChatPayCode.Success && response.ResultCode == WeChatPayCode.Success)
            {
                return refundInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
