using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using Core.Services;

namespace 通用订票.Application.System.Services.IService
{
    public interface IWechatBillService : IBaseService<WechatBill>
    {
        Task<WechatBill> UpdateStatus(BillPaymentsStatus status, long trade_no,string transactionId = "");
        Task<WechatBill> GenWechatBill(通用订票.Core.Entity.Order order, WechatBillAttach attach,long userId);
        Task<WechatBill> GetWechatBill(long trade_no);
    }
}
