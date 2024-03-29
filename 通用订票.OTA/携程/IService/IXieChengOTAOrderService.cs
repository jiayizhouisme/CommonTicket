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

        void SetService(IDefaultOrderServices service);
    }
}
