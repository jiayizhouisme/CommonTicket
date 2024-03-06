using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.OTAService.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.OTAService
{
    public class MeiTuanOTAOrderService : 
        BaseService<Core.Entity.Order,MasterDbContextLocator>,
        IMeiTuanOTAOrderService
        ,ITransient
    {
        private IDefaultOrderServices _orderServices { get; set; }
        public Task<Core.Entity.Order> CancelOrder(Core.Entity.Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entity.Order> PayOrder(Core.Entity.Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entity.Order> RefundOrder(Core.Entity.Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entity.Order> TakeOrder(decimal amount, OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }
    }
}
