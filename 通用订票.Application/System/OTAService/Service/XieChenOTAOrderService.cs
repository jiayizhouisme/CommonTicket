using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.OTAService.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.OTAService
{
    public class XieChenOTAOrderService : 
        BaseService<XieChenOrder,MasterDbContextLocator>,
        IXieChenOTAOrderService
        ,ITransient
    {
        private IDefaultOrderServices _orderServices { get; set; }
        public Task<XieChenOrder> CancelOrder(XieChenOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChenOrder> PayOrder(XieChenOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChenOrder> RefundOrder(XieChenOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChenOrder> TakeOrder(decimal amount, OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }
    }
}
