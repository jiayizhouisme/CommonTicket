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

namespace 通用订票.OTA.携程.IService
{
    public interface IXieChengOTAOrderService : IBaseService<XieChengOrder>
    {
        Task<XieChengOrder[]> QueryXieChengOrder(string otaOrderId);
        Task<XieChengOrder[]> CreateXieChengOrder(XiechengCreateOrder order);
        Task<bool> CanclePreOrder(string otaOrderId);
        Task<string[]> GetPassengersIds(string otaOrderId, string itemId);
        Task<XieChengConfig> GetConfig(string tenant_id);
        void SetService(IDefaultOrderServices service);
    }
}
