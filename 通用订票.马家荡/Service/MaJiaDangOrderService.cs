using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票Order.Entity;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace 通用订票.测试项目1.Service
{
    [Injection(Order = 0)]
    public class MaJiaDangOrderService : DefaultOrderService, ITransient
    {
        private ILogger _log { get; set; }

        public MaJiaDangOrderService(IRepository<Core.Entity.Order, MasterDbContextLocator> _dal, ICacheOperation cache, ILoggerFactory logger) : base(_dal, cache)
        {
            _log = logger.CreateLogger("MaJiaDangOrder");
        }

        public override Task<Core.Entity.Order> CreateOrder(Guid objectId, string name, decimal amount, OrderStatus status = OrderStatus.未付款)
        {
            _log.Log(LogLevel.Information, "测试项目1订单开始下单");
            return base.CreateOrder(objectId, name + "测试项目1", amount, status);
        }

    }
}