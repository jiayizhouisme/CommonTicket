using Core.Services;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public abstract class OrderBaseService<T> : BaseService<T>, IOrderService<T> where T : Core.Entity.Order, new() 
    {
        public OrderBaseService(IRepository<T> _dal)
        {
            base._dal = _dal;
        }
        public virtual async Task<T> TakeOrder(decimal amount)
        {
            if (amount < 0)
            {
                return null;
            }
            Random rand = new Random();
            T order = new T();

            order.status = OrderStatus.未付款;
            order.trade_no = GetTradeNo();
            order.payedAmount = 0;
            order.amount = amount;
            /*
             * 微信下单,支付宝下单...
             */
            return order;
        }

        public virtual async Task<T> CancelOrder(T order)
        {
            if (order.status != OrderStatus.未付款)
            {
                return null;
            }
            /*
             * 微信,支付宝关闭订单
             */
            order.status = OrderStatus.已关闭;

            return order;
        }

        public virtual async Task<T> PayOrder(T order)
        {
            if (order.status != OrderStatus.未付款)
            {
                return null;
            }
            /*
             * 微信支付,支付宝支付...
             */
            order.status = OrderStatus.支付中;

            return order;
        }

        public virtual async Task<T> RefundOrder(T order)
        {
            if (order.status != OrderStatus.已付款)
            {
                return null;
            }
            order.status = OrderStatus.已退款;
            return order;
        }

        public virtual async Task<T> CreateOrder(Guid objectId, string name,decimal amount)
        {
            try
            {
                var order = await TakeOrder(amount);
                order.objectId = objectId;
                order.createTime = DateTime.Now;
                order.name = "普通订单:" + name;
                return order;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<T> PayFinished(T order)
        {
            try
            {
                order.status = OrderStatus.已付款;
            }
            catch
            {
                throw;
            }
            return order;
        }

        public virtual async Task AfterOrderToke(long orderId)
        {

        }

        protected virtual long GetTradeNo()
        {
            DateTime currentTime = DateTime.Now;
            string originDateStr = currentTime.ToString("yyMMdd");
            long differSecond = currentTime.Minute * 60 + currentTime.Second;

            string yyMMddSecond = originDateStr + differSecond.ToString().PadLeft(5,'0');
            return long.Parse(yyMMddSecond);
        }

    }
}
