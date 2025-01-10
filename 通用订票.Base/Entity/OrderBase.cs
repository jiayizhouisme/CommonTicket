using 通用订票Order.Entity;

namespace 通用订票.Order.Entity
{
    /// <summary>
    /// 门票订单
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OrderBase<T> : OrderAbstract
    {
        public string objectId { get; set; }
        public Guid exhibitionId { get; set; }
        /// <summary>
        /// 下单用户ID
        /// </summary>
        public T userId { get; set; }

        /// <summary>
        /// 订单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int count { get; set; }

    }
}
