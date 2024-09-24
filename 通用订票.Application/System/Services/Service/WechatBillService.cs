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
using Core.Utill.UniqueCode;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatBillService : BaseService<WechatBill, MasterDbContextLocator>, IWechatBillService, ITransient
    {
        private readonly ICacheOperation _cache;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IIdGenerater<long> idGenerater;
        public WechatBillService
            (IRepository<WechatBill, MasterDbContextLocator> _dal, ICacheOperation _cache, IHttpContextAccessor httpContextAccessor, IIdGenerater<long> idGenerater)
        {
            this._dal = _dal;
            this._cache = _cache;
            this.httpContextAccessor = httpContextAccessor;
            this.idGenerater = idGenerater;
        }

        public async Task<WechatBill> GenWechatBill(通用订票.Core.Entity.Order order, WechatBillAttach attach, long userId)
        {
            var bill = await GetWechatBill(order.trade_no);
            if (bill != null && bill.status == BillPaymentsStatus.NoPay)
            {
                return bill;
            }
            var tradeType = "JSAPI";
            bill = new WechatBill();
            bill.paymentId = await idGenerater.Generate("paymentId");
            bill.status = BillPaymentsStatus.NoPay;
            bill.paymentCode = tradeType;
            bill.createTime = DateTime.Now;
            bill.ip = httpContextAccessor.HttpContext.GetRemoteIpAddressToIPv4();
            bill.payTitle = order.name;
            bill.tradeNo = order.trade_no;
            bill.money = order.amount * 100;
            bill.Attach = JsonConvert.SerializeObject(attach);
            bill.userId = userId;
            if (bill.money == 0)
            {
                bill.status = BillPaymentsStatus.Payed;
            }
            else
            {
                bill.status = BillPaymentsStatus.NoPay;
            }

            await this.AddNow(bill);
            await _cache.Set("Bill:" + bill.tradeNo, bill, 600);
            return bill;
        }

        public async Task<WechatBill> GetWechatBill(long trade_no)
        {
            var now = DateTime.Now;
            var key = "Bill:" + trade_no;
            var bill= await _cache.Get<WechatBill>(key);
            if (bill == null)
            {
                
                bill = await this.GetQueryableNt(a => a.tradeNo == trade_no).OrderByDescending(a => a.paymentId).FirstOrDefaultAsync();
                if (bill != null && now.Subtract(bill.createTime).TotalHours < 2)
                {
                    await _cache.Set(key,bill,600);
                }
                else
                {
                    return null;
                }
            }
            else if(now.Subtract(bill.createTime).TotalHours > 2)
            {
                return null;
            }
            return bill;
        }

        public override async Task<WechatBill> UpdateNow(WechatBill wechatBill)
        {
            wechatBill.updateTime = DateTime.Now;
            await base.UpdateNow(wechatBill);
            await _cache.Del("Bill:" + wechatBill.tradeNo);
            return wechatBill;
        }

        public async Task<WechatBill> UpdateStatus(BillPaymentsStatus status, long trade_no, string transactionId = "")
        {
            var wechatBill = await this.GetWechatBill(trade_no);
            
            if (wechatBill != null)
            {
                wechatBill.status = status;
                if (!string.IsNullOrEmpty(transactionId))
                {
                    wechatBill.transactionId = transactionId;
                }
                await UpdateNow(wechatBill);
            }
            return wechatBill;
        }
    }
}
