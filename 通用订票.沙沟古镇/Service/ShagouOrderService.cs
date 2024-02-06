﻿using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票Order.Entity;

namespace 通用订票.沙沟古镇.Service
{
    [Injection(Order = 0)]
    public class ShagouOrderService : DefaultOrderService, ITransient
    {
        private ILogger _log { get; set; }

        public ShagouOrderService(IRepository<Core.Entity.Order> _dal, ICacheOperation cache, ILoggerFactory logger) : base(_dal, cache)
        {
            _log = logger.CreateLogger("ShagouOrder");
        }

        public override Task<Core.Entity.Order> CreateOrder(Guid objectId, string name, decimal amount, OrderStatus status = OrderStatus.未付款)
        {
            _log.Log(LogLevel.Information,"沙沟订票订单开始下单");
            return base.CreateOrder(objectId, name + "沙沟", amount);
        }

    }
}