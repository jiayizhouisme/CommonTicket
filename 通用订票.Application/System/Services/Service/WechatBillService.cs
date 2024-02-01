using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Request;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using Core.Auth;
using StackExchange.Profiling.Internal;
using Core.Cache;
using Core.Services;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatBillService : BaseService<WechatBill>, IWechatBillService,ITransient
    {
        private readonly WeChatPayOptions _wechatpay;
        private readonly IWeChatPayClient _client;
        private readonly IHttpContextUser _user;
        private readonly IUserService _userServices;
        private readonly ICacheOperation _cache;
        public WechatBillService(IOptions<WeChatPayOptions> _wechatpay, IRepository<WechatBill> _dal, IUserService _userServices,
            IWeChatPayClient _client, IHttpContextUser _user, ICacheOperation _cache)
        {
            this._dal = _dal;
            this._userServices = _userServices;
            this._user = _user;
            this._client = _client;
            //this._wechatpay = _wechatpay.Value;
            this._cache = _cache;
        }

        public async Task<WechatBill> GenWechatBill(WechatBill entity)
        {
            //var jm = new WebApiCallBack();
            var billInCache = await _cache.Get<WechatBill>("Bill:" + entity.tradeNo);
            if (billInCache != null)
            {
                return billInCache;
            }
            var weChatPayUrl = "http://127.0.0.1/payback";
            if (string.IsNullOrEmpty(weChatPayUrl))
            {
                return null;
            }

            var tradeType = "JSAPI";

            var openId = "oBuO66JLrmascVJYSMWEeVlIjigE";

            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = entity.payTitle.Length > 50 ? entity.payTitle[..50] : entity.payTitle,
                OutTradeNo = entity.tradeNo.ToString(),
                TotalFee = Convert.ToInt32(entity.money * 100),
                SpBillCreateIp = entity.ip,
                NotifyUrl = weChatPayUrl,
                TradeType = tradeType,
                OpenId = openId,
                Attach = entity.orderId.ToString()
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
                //entity.id = Guid.NewGuid();
                //await this.Add(entity);
                entity.parameters = parameter.ToJson();
                await _cache.Set("Bill:" + entity.tradeNo,entity,600);
                return entity;
            }
            else
            {
                return null;
            }

            return null;
        }
    }
}
