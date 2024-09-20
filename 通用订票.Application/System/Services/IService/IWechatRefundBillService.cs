using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using Core.Services;

namespace 通用订票.Application.System.Services.IService
{
    public interface IWechatRefundBillService : IBaseService<WechatBillRefund>
    {
        Task<WechatBillRefund> UpdateStatus(RefundStatus status, long trade_no);
        Task<WechatBillRefund> GenWechatRefundBill(WechatBill bill);
        Task<WechatBillRefund> GetWechatRefundBill(long trade_no);
    }
}
