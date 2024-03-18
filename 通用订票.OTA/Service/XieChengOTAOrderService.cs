using Core.Services;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.OTAService.IService;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.OTAService
{
    public class XieChengOTAOrderService :
        BaseService<XieChengOrder, MasterDbContextLocator>,
        IXieChengOTAOrderService
        ,ITransient
    {
        private IDefaultOrderServices _orderServices { get; set; }

        public XieChengOTAOrderService(IRepository<XieChengOrder, MasterDbContextLocator> _dal)
        {
            base._dal = _dal;
        }

        public Task<XieChengOrder> CancelOrder(XieChengOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChengOrder> PayOrder(XieChengOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChengOrder> RefundOrder(XieChengOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<XieChengOrder> TakeOrder(decimal amount, OrderStatus status, string extraInfo = null)
        {
            throw new NotImplementedException();
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }
    }
}
