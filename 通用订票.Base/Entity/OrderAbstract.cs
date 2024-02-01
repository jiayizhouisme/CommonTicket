namespace 通用订票Order.Entity
{
    public abstract class OrderAbstract
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public long trade_no { get; set; }

        /// <summary>
        /// 金额总数
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 已支付的金额
        /// </summary>
        public decimal payedAmount { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public OrderStatus status { get; set; }
        public DateTime createTime { get; set; }
    }
    public enum OrderStatus
    {
        未付款 = 0,
        已付款 = 1,
        已关闭 = 2,
        已退款 = 3,
        一部分退款 = 4,
        支付中 = 5
    }
}
