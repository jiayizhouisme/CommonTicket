using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Order.IService;

namespace 通用订票.Application.System.OTAService.IService
{
    public interface IXieChenOTAOrderService : IBaseOrderService<XieChenOrder>,IBaseService<XieChenOrder>
    {
        void SetService(IDefaultOrderServices service);
    }
}
