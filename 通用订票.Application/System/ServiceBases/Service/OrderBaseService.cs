using Core.Services;
using Core.Utill.UniqueCode;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Base.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public abstract class OrderBaseService<T, DbLocator> : BaseService<T, DbLocator>, IOrderService<T> where T : Core.Entity.Order, new() where DbLocator : class, IDbContextLocator
    {
        private readonly ITradeNoGenerater<long> tradeNoGenerate;
        public OrderBaseService(ITradeNoGenerater<long> tradeNoGenerate,IRepository<T, DbLocator> _dal)
        {
            base._dal = _dal;
            this.tradeNoGenerate = tradeNoGenerate;
        }
        public virtual async Task<T> TakeOrder(decimal amount,OrderStatus status, string extraInfo = null)
        {
            if (amount < 0)
            {
                return null;
            }
            Random rand = new Random();
            T order = new T();

            order.status = status;
            order.trade_no = await GenerateTradeNo();
            order.payedAmount = 0;
            order.amount = amount;
            order.extraInfo = extraInfo;
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
            if (order.status != OrderStatus.退款中)
            {
                return null;
            }
            order.status = OrderStatus.已退款;
            return order;
        }

        public virtual async Task<T> PreRefundOrder(T order)
        {
            if (order.status != OrderStatus.已付款)
            {
                return null;
            }
            order.status = OrderStatus.退款中;
            return order;
        }

        public virtual async Task<T> CreateOrder(string objectId, string name, Guid exhibitionId,decimal amount,int count, OrderStatus os, string extraInfo = null)
        {
            var order = await TakeOrder(amount, os, extraInfo);
            order.objectId = objectId;
            order.createTime = DateTime.Now;
            order.name = name;
            order.count = count;
            order.exhibitionId = exhibitionId;
            order.extraInfo = extraInfo;
            if (order.amount == 0)
            {
                order.payedTime = order.createTime.ToString();
            }
            else
            {
                order.payedTime = "";
            }
            return order;
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

        public virtual async Task<Core.Entity.Order> OnCloseException(Core.Entity.Order order)
        {
            order.status = OrderStatus.未付款;
            return order;
        }

        public async Task<long> GenerateTradeNo()
        {
            return await tradeNoGenerate.Generate();
        }
    }
}
