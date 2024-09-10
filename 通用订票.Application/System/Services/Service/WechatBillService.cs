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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Web;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatBillService : BaseService<WechatBill, MasterDbContextLocator>, IWechatBillService,ITransient
    {
        private readonly ICacheOperation _cache;
        private readonly IHttpContextAccessor httpContextAccessor;
        public WechatBillService(IRepository<WechatBill, MasterDbContextLocator> _dal,ICacheOperation _cache, IHttpContextAccessor httpContextAccessor)
        {
            this._dal = _dal;
            this._cache = _cache;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<WechatBill> GenWechatBill(通用订票.Core.Entity.Order order, WechatBillAttach attach, long userId)
        {
            var bill = await GetWechatBill(order.trade_no);
            if (bill != null)
            {
                return bill;
            }
            var tradeType = "JSAPI";
            bill = new WechatBill();
            bill.status = 通用订票Order.Entity.OrderStatus.未付款;
            bill.paymentCode = tradeType;
            bill.createTime = DateTime.Now;
            bill.ip = httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4();
            bill.payTitle = order.name;
            bill.tradeNo = order.trade_no;
            bill.money = order.amount;
            bill.Attach = JsonConvert.SerializeObject(attach);
            bill.userId = userId;
            if (bill.money == 0)
            {
                bill.status = 通用订票Order.Entity.OrderStatus.已付款;
            }
            else
            {
                bill.status = 通用订票Order.Entity.OrderStatus.未付款;
            }
            
            await this.AddNow(bill);
            await _cache.Set("Bill:" + bill.tradeNo, bill.parameters,600);
            return bill;
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
                    await _cache.Set(key,bill,600);
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
