using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Base.TradeNo;
using 通用订票Order.Entity;

namespace 通用订票.小景区.Service
{
    [Injection(Order = 0)]
    public class ShagouOrderService : DefaultOrderService, ITransient
    {
        private ILogger _log { get; set; }

        public ShagouOrderService(
            ITradeNoGenerate<long> tradeNoGenerate,
            IRepository<Core.Entity.Order, MasterDbContextLocator> _dal,
            ICacheOperation cache, ILoggerFactory logger) 
            : base(tradeNoGenerate,_dal, cache)
        {
            _log = logger.CreateLogger("ShagouOrder");
        }

        public override Task<Core.Entity.Order> CreateOrder(string objectId, string name, decimal amount, OrderStatus status = OrderStatus.未付款, string extraInfo = null)
        {
            _log.Log(LogLevel.Information, "测试项目2订单开始下单");
            return base.CreateOrder(objectId, name + "测试项目2", amount, status, extraInfo);
        }

    }
}