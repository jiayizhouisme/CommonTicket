using 通用订票Order.Entity;

namespace 通用订票.Order.IService
{
    public interface IBaseOrderService<T> where T : OrderAbstract,new()
    {
        /// <summary>
        /// 下单
        /// </summary>
        /// <returns></returns>
        public Task<T> TakeOrder(decimal amount,OrderStatus status, string extraInfo = null);

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <returns></returns>
        public Task<T> CancelOrder(T order);

        /// <summary>
        /// 退款
        /// </summary>
        /// <returns></returns>
        public Task<T> RefundOrder(T order);

        public Task<T> PreRefundOrder(T orer);

        /// <summary>
        /// 支付订单
        /// </summary>
        /// <returns></returns>
        public Task<T> PayOrder(T order);
    }
}
