using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using 订票系统.Rules.IService;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using Core.Auth;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    [Injection(Order = 1)]
    public class MyOrderService : OrderBaseService<Core.Entity.Order>, IMyOrderServices, ITransient
    {
        private Guid userId { get; set; }
        private readonly MyBeetleX _cache;
        public MyOrderService(IRepository<Core.Entity.Order> _dal, MyBeetleX cache) : base(_dal)
        {
            _cache = cache;
        }

        public override async Task<Core.Entity.Order> TakeOrder(decimal amount)
        {
            var order = await base.TakeOrder(amount);
            order.userId = userId;
            return order;
        }

        public override async Task<Core.Entity.Order> CreateOrder(Guid objectId, string name, decimal amount)
        {
            var result = await base.CreateOrder(objectId, name, amount);
            var r = await this._dal.InsertNowAsync(result);
            await SetOrderToCache(r.Entity);
            return r.Entity;
        }

        public override async Task<Core.Entity.Order> CancelOrder(Core.Entity.Order Order)
        {
            var order = await base.CancelOrder(Order);
            if (order != null)
            {
                await this.UpdateNow(order);
                await SetOrderToCache(Order);
            }
            return order;
        }

        public override async Task<Core.Entity.Order> PayOrder(Core.Entity.Order Order)
        {
            var result = await base.PayOrder(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await SetOrderToCache(Order);
            }
            return result;
        }

        public override async Task<Core.Entity.Order> PayFinished(Core.Entity.Order Order)
        {
            var result = await base.PayFinished(Order);
            if (result != null)
            {
                await this.UpdateNow(Order);
                await SetOrderToCache(Order);
            }
            return result;
        }

        public virtual void SetUserContext(Guid userId)
        {
            this.userId = userId;
        }

        public virtual async Task SetOrderToCache(Core.Entity.Order order)
        {
            if (order == null)
            {
                return;
            }
            var key = "Order_" + order.id;
            await _cache.Set(key,order,650);
        }

        public virtual async Task<Core.Entity.Order> GetOrderById(Guid orderId)
        {
            var key = "Order_" + orderId.ToString();
            var orderCache = await _cache.Get<Core.Entity.Order>(key);
            if (orderCache != null)
            {
                return orderCache;
            }

            var result = this.GetQueryableNt(a => a.id == orderId).Select(a => new Core.Entity.Order
            {
                amount = a.amount,
                id = a.id,
                _id = a._id,
                createTime = a.createTime,
                name = a.name,
                trade_no = a.trade_no,
                userId = a.userId,
                status = a.status,
                payedAmount = a.payedAmount,
                objectId = a.objectId
            });
            var _result = await result.FirstOrDefaultAsync();
            if (_result == null)
            {
                return null;
            }
            await SetOrderToCache(_result);
            return _result;
        }

        public override async Task AfterOrderToke(Guid orderId)
        {
            await this.DelOrderFromCache(orderId);
        }
        private async Task DelOrderFromCache(Guid id)
        {
            var key = "Order_" + id.ToString();
            await _cache.Del(key);
        }
    }
}
