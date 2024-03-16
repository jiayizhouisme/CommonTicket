using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Order.IService;
using 通用订票.OTA.Entity;

namespace 通用订票.Application.System.OTAService.IService
{
    public interface IXieChengOTAOrderService : IBaseOrderService<XieChengOrder>,IBaseService<XieChengOrder>
    {
        void SetService(IDefaultOrderServices service);
    }
}
