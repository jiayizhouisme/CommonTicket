using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IOrderService<T> : 通用订票.Order.IService.IBaseOrderService<T>,IBaseService<T> where T : Core.Entity.Order,new()
    {
        public Task<T> CreateOrder(Guid objectId,string name,decimal amount);
        public Task<T> PayFinished(T order);
        public Task AfterOrderToke(Guid orderId);
    }
}
