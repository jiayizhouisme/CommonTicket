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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatPayService : IWechatPayService,ISingleton
    {
        private readonly IWeChatPayClient _client;

        public WechatPayService(IWeChatPayClient _client)
        {
            this._client = _client;
        }
        public async Task<WeChatPayDictionary> PubPay(WechatBill entity,WechatMerchantConfig config,string openid)
        {
            WeChatPayOptions _wechatpay = new WeChatPayOptions();
            _wechatpay.APIKey = config.apiKey;
            _wechatpay.MchId = config.mchId;
            _wechatpay.AppId = config.appid;
            _wechatpay.RsaPublicKey = config.rsaPublicKey;
            _wechatpay.Certificate = config.certificate;

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
                TotalFee = Convert.ToInt32(entity.money),
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
                return parameter;
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
            if (entity.status != BillPaymentsStatus.Payed)
            {
                return null;
            }
            var weChatRefundUrl = "";
            WeChatPayOptions _wechatpay = config.Adapt<WeChatPayOptions>();
            var request = new WeChatPayRefundRequest
            {
                OutRefundNo = refundInfo.refundId.ToString(),
                TransactionId = entity.transactionId,
                OutTradeNo = entity.paymentId.ToString(),
                TotalFee = Convert.ToInt32(entity.money),
                RefundFee = Convert.ToInt32(refundInfo.money),
                NotifyUrl = weChatRefundUrl
            };
            var response = await _client.ExecuteAsync(request, _wechatpay);
            refundInfo.memo = response.ErrCodeDes;
            
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
