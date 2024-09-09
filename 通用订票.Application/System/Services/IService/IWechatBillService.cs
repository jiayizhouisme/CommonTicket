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
        Task<WechatBill> UpdateStatus(通用订票Order.Entity.OrderStatus status, long trade_no);
        Task<WechatBill> GenWechatBill(WechatBill bill,string openId);
        Task<WechatBill> GetWechatBill(long trade_no);
    }
}
