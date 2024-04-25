using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Order.IService;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.Model;
using 通用订票.Web.Entry.Controllers;

namespace 通用订票.OTA.携程.IService
{
    public interface IXieChengOTAOrderService : IBaseService<XieChengOrder>
    {
        Task<XieChengOrderQueryResponseWithHeader> QueryXieChengOrder(string otaOrderId);
        Task<XieChengPreOrderResponse> CreateXieChengOrder(XiechengCreateOrder order);
        Task<XieChengPayPre> PayPreOrder(XiechengPayPreOrder order);
        Task<XieChengPayPreConfirmResponseWithHeader> PayPreConfirm(XiechengPayPreOrder data);
        Task<bool> CanclePreOrder(XieChengOrderQuery query);
        Task<XieChengCancelOrderResponse> CancelOrder(XieChengCancelOrder order);
        Task<XieChengCancelOrderConfirm> CancleOrderConfirm(XieChengCancelOrder order);
        Task<XieChengTIcketVerifyResult> Verify(string ticket_number, int useCount,string exhibition);
        Task<string[]> GetPassengersIds(string otaOrderId, string itemId);
        Task<XieChengConfig> GetConfig(string tenant_id);
        Task<ICollection<XieChengOrder>> GetOrder(string otaOrderId);
        void SetService(IDefaultOrderServices service);
        void SetTenant(string tenant_id);
    }
}
