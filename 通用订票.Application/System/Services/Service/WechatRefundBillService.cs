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
    public class WechatRefundBillService : BaseService<WechatBillRefund, MasterDbContextLocator>, IWechatRefundBillService, ITransient
    {
        private readonly IIdGenerater<long> idGenerater;
        public WechatRefundBillService
            (IRepository<WechatBillRefund, MasterDbContextLocator> _dal, IIdGenerater<long> idGenerater)
        {
            this._dal = _dal;
            this.idGenerater = idGenerater;
        }

        public async Task<WechatBillRefund> GenWechatRefundBill(WechatBill bill)
        {
            var refundBill = await GetWechatRefundBill(bill.tradeNo);
            if (refundBill != null)
            {
                if (refundBill.status != RefundStatus.退款失败)
                {
                    return null; //已经退款或者正在退款流程
                }
                return refundBill;
            }
            var tradeType = "JSAPI";
            refundBill = new WechatBillRefund();
            refundBill.refundId = await idGenerater.Generate("refundId");
            refundBill.status = RefundStatus.未退款;
            refundBill.paymentCode = tradeType;
            refundBill.tradeNo = bill.paymentId;
            refundBill.createTime = DateTime.Now;
            refundBill.money = bill.money;
            if (refundBill.money == 0)
            {
                refundBill.status = RefundStatus.已退款;
            }

            await this.AddNow(refundBill);
            return refundBill;
        }

        public async Task<WechatBillRefund> GetWechatRefundBill(long trade_no)
        {
            var bill = await this.GetQueryableNt(a => a.tradeNo == trade_no).OrderByDescending(a => a.createTime).FirstOrDefaultAsync();
            return bill;
        }

        public async Task<WechatBillRefund> UpdateStatus(RefundStatus status, long trade_no)
        {
            var wechatBill = await this.GetWechatRefundBill(trade_no);
            
            if (wechatBill != null)
            {
                wechatBill.status = status;
                await UpdateNow(wechatBill);
            }
            return wechatBill;
        }
    }
}
