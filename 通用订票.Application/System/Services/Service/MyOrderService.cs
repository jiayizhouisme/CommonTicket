﻿using System;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using BeetleX.Redis;
using System.Security.AccessControl;
using static BeetleX.Redis.Commands.HSCAN;

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
            result.trade_no = await GetTradeNoAsync(result.trade_no);
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
            var key = "Order_" + order.trade_no;
            await _cache.Set(key,order,650);
        }

        public virtual async Task<Core.Entity.Order> GetOrderById(string trade_no)
        {
            var key = "Order_" + trade_no;
            var orderCache = await _cache.Get<Core.Entity.Order>(key);
            if (orderCache != null)
            {
                return orderCache;
            }

            var result = this.GetQueryableNt(a => a.trade_no == trade_no).Select(a => new Core.Entity.Order
            {
                amount = a.amount,
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

        public override async Task AfterOrderToke(string trande_no)
        {
            await this.DelOrderFromCache(trande_no);
        }

        protected async Task<string> GetTradeNoAsync(string before)
        {
            string prefixOrder = before;
            //通过key，采用redis自增函数，实现单秒自增；不同的key，从0开始自增，同时设置60秒过期
            long? res = await _cache.Get<long>("TradeNo");
            if (res == null)
            {
                await _cache.Set("TradeNo", 0, 60);
            }
            res = await _cache.Incr("TradeNo");
            
            //生成订单编号
            string orderNo = prefixOrder + res.ToString().PadLeft(4, '0');
            return orderNo;
        }

        private async Task DelOrderFromCache(string trande_no)
        {
            var key = "Order_" + trande_no;
            await _cache.Del(key);
        }
    }
}
