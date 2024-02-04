using Core.Services;
using 通用订票.Order.IService;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IOrderService<T> : IBaseOrderService<T>,IBaseService<T> where T : Core.Entity.Order,new()
    {
        public Task<T> CreateOrder(Guid objectId,string name,decimal amount);
        public Task<T> PayFinished(T order);
        public Task AfterOrderToke(long orderId);
    }
}
