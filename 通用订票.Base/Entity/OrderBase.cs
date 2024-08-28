using 通用订票Order.Entity;

namespace 通用订票.Order.Entity
{
    /// <summary>
    /// 门票订单
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OrderBase<T> : OrderAbstract
    {
        /// <summary>
        /// 关联ID
        /// </summary>
        public string objectId { get; set; }

        /// <summary>
        /// 下单用户ID
        /// </summary>
        public T userId { get; set; }

        /// <summary>
        /// 订单名称
        /// </summary>
        public string name { get; set; }

    }
}
