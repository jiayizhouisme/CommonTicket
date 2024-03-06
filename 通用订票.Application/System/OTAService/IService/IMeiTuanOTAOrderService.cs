using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Order.IService;

namespace 通用订票.Application.System.OTAService.IService
{
    public interface IMeiTuanOTAOrderService : IBaseOrderService<Core.Entity.Order>,IBaseService<Core.Entity.Order>
    {
        void SetService(IDefaultOrderServices service);
    }
}
