using Core.Cache;
using Core.Utill.UniqueCode;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票Order.Entity;

namespace 通用订票.Application.System.Services.Service
{
    [Injection(Order = 1)]
    public class DefaultOrderService : OrderBaseService<Core.Entity.Order, MasterDbContextLocator>, IDefaultOrderServices, ITransient
    {
        private long userId { get; set; }
        private readonly ICacheOperation _cache;
        public DefaultOrderService(ITradeNoGenerater<long> tradeNoGenerate,IRepository<Core.Entity.Order, MasterDbContextLocator> _dal, ICacheOperation cache) : base(tradeNoGenerate,_dal)
        {
            _cache = cache;
        }

        public override async Task<Core.Entity.Order> TakeOrder(decimal amount,OrderStatus status, string extraInfo = null)
        {
            var order = await base.TakeOrder(amount, status,extraInfo);
            order.userId = userId;
            return order;
        }

        public virtual async Task<Core.Entity.Order> CreateOrder(string objectId, string name,Guid exhibitionId, int day, decimal amount,int count, string extraInfo = null)
        {
            OrderStatus os = OrderStatus.未付款;
            if (amount == 0)
            {
                os = OrderStatus.已付款;
            }
            var result = await base.CreateOrder(objectId, name,exhibitionId, amount,count, os,extraInfo);
            result.ticketStatus = Base.Entity.TicketStatus.未使用;
            result.expireDate = DateTime.Now.Date.AddDays(day + 1);
            var r = await this._dal.InsertNowAsync(result);
            await SetOrderToCache(r.Entity);
            await AfterOrdered(objectId);
            return r.Entity;
        }

        public override async Task<Core.Entity.Order> CreateOrder(string objectId, string name,Guid exhibitionId, decimal amount,int count, OrderStatus os, string extraInfo = null)
        {
            var result = await base.CreateOrder(objectId, name, exhibitionId,amount, count,os, extraInfo);
            var r = await this._dal.InsertNowAsync(result);
            await SetOrderToCache(r.Entity);
            await AfterOrdered(objectId);
            return r.Entity;
        }

        public override async Task<Core.Entity.Order> CancelOrder(Core.Entity.Order Order)
        {
            var order = await base.CancelOrder(Order);
            if (order != null)
            {
                await this.UpdateNow(order);
                await DelOrderFromCache(order.trade_no);
            }
            return order;
        }

        public override async Task<Core.Entity.Order> PayOrder(Core.Entity.Order Order)
        {
            var result = await base.PayOrder(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await DelOrderFromCache(Order.trade_no);
            }
            return result;
        }

        public override async Task<Core.Entity.Order> RefundOrder(Core.Entity.Order Order)
        {
            var result = await base.RefundOrder(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await DelOrderFromCache(Order.trade_no);
            }
            return result;
        }

        public override async Task<Core.Entity.Order> PreRefundOrder(Core.Entity.Order Order)
        {
            var result = await base.PreRefundOrder(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await DelOrderFromCache(Order.trade_no);
            }
            return result;
        }

        public override async Task<Core.Entity.Order> PayFinished(Core.Entity.Order Order)
        {
            var result = await base.PayFinished(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await DelOrderFromCache(Order.trade_no);
            }
            return result;
        }

        public virtual void SetUserContext(long userId)
        {
            this.userId = userId;
        }

        public virtual async Task SetOrderToCache(Core.Entity.Order order)
        {
            if (order == null)
            {
                return;
            }
            var key = "Order:" + order.trade_no;
            await _cache.Set(key,order,650);
        }

        public virtual async Task<Core.Entity.Order> GetOrderById(long trade_no)
        {
            var key = "Order:" + trade_no;
            var orderCache = await _cache.Get<Core.Entity.Order>(key);
            if (orderCache != null)
            {
                return orderCache;
            }

            var result = this.GetQueryableNt(a => a.trade_no == trade_no).Select(a => new Core.Entity.Order
            {
                amount = a.amount,
                createTime = a.createTime,
                name = a.name,
                trade_no = a.trade_no,
                userId = a.userId,
                status = a.status,
                payedAmount = a.payedAmount,
                objectId = a.objectId,
                extraInfo = a.extraInfo,
                count = a.count,
                payedTime = a.payedTime,
                exhibitionId = a.exhibitionId
            });
            var _result = await result.FirstOrDefaultAsync();
            if (_result == null)
            {
                return null;
            }
            await SetOrderToCache(_result);
            return _result;
        }

        public override async Task AfterOrderToke(long trande_no)
        {
            await this.DelOrderFromCache(trande_no);
        }

        public override async Task<Core.Entity.Order> OnCloseException(Core.Entity.Order order)
        {
            order = await base.OnCloseException(order);
            await this.UpdateNow(order);
            return order;
        }

        public async Task<bool> PreOrder(string objectId)
        {
            var _lock = await _cache.LockNoWait("PreOrder:" + objectId.ToString() + ":User:" + userId, userId.ToString(), 60);
            if (_lock == 0)
            {
                return false;
            }

            var ret = await _cache.Get<int>("Orderd:" + objectId.ToString() + ":User:" + userId);
            if (ret == 1)
            {                
                await this.OrderFail(objectId);
                return false;
            }
            return true;
        }

        public async Task OrderFail(string objectId)
        {
            await ReleaseLock(objectId);
        }

        public virtual async Task AfterOrdered(string objectId)
        {
            await ReleaseLock(objectId);
        }

        public async Task DelOrderFromCache(long trande_no)
        {
            var key = "Order:" + trande_no;
            await _cache.Del(key);
        }

        private async Task ReleaseLock(string objectId)
        {
            await _cache.ReleaseLock("PreOrder:" + objectId.ToString() + ":User:" + userId, userId.ToString());//解锁 
        }
    }
}
