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
using Furion.JsonSerialization;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatBillService : BaseService<WechatBill, MasterDbContextLocator>, IWechatBillService,ITransient
    {
        private readonly IWechatMerchantConfigService _merchantConfigService;
        private readonly IWeChatPayClient _client;
        private readonly ICacheOperation _cache;
        public WechatBillService(IRepository<WechatBill, MasterDbContextLocator> _dal,
            IWeChatPayClient _client,ICacheOperation _cache, IWechatMerchantConfigService merchantConfigService)
        {
            this._dal = _dal;
            this._client = _client;
            this._cache = _cache;
            _merchantConfigService = merchantConfigService;
        }

        public async Task<WechatBill> GenWechatBill(WechatBill entity,string openId)
        {
            var config = await _merchantConfigService.GetConfig();
            if (config == null)
            {
                return null;
            }
            WeChatPayOptions _wechatpay = config.Adapt<WeChatPayOptions>();

            var bill = await GetWechatBill(entity.tradeNo);
            if (bill != null)
            {
                return bill;
            }
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
                OutTradeNo = entity.tradeNo.ToString(),
                TotalFee = Convert.ToInt32(entity.money * 100),
                SpBillCreateIp = entity.ip,
                NotifyUrl = weChatPayUrl,
                TradeType = tradeType,
                OpenId = openId,
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
                entity.status = 通用订票Order.Entity.OrderStatus.未付款;
                entity.paymentCode = tradeType;
                await this.AddNow(entity);
                await _cache.Set("Bill:" + entity.tradeNo,entity.parameters,600);
                return entity;
            }
            else
            {
                return null;
            }

            return null;
        }

        public async Task<WechatBill> GetWechatBill(long trade_no)
        {
            var now = DateTime.Now;
            var key = "Bill:" + trade_no;
            var bill= await _cache.Get<WechatBill>(key);
            if (bill == null)
            {
                
                bill = await this.GetQueryableNt(a => a.tradeNo == trade_no).FirstOrDefaultAsync();
                if (bill != null && now.Subtract(bill.createTime).Hours < 2)
                {
                    await _cache.Set(key,bill);
                }
                else
                {
                    return null;
                }
            }
            else if(now.Subtract(bill.createTime).Hours < 2)
            {
                return null;
            }
            return bill;
        }

        public async Task<WechatBill> UpdateStatus(OrderStatus status, long trade_no)
        {
            var wechatBill = await this.GetWechatBill(trade_no);
            if (wechatBill != null)
            {
                var key = "Bill:" + trade_no;
                wechatBill.status = status;
                await this.UpdateNow(wechatBill);
                await _cache.Del(key);
            }
            return wechatBill;
        }
    }
}
