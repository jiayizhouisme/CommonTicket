using Core.Services;
using 通用订票.Order.IService;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IOrderService<T> : IBaseOrderService<T>, IBaseService<T> where T : Core.Entity.Order,new()
    {
        public Task<T> CreateOrder(Guid objectId,string name,decimal amount,OrderStatus status = OrderStatus.未付款, string extraInfo = null);
        public Task<T> PayFinished(T order);
        public Task AfterOrderToke(long orderId);
        public Task<Core.Entity.Order> OnCloseException(Core.Entity.Order order);
        public Task<long> GenerateTradeNo();
    }
}
