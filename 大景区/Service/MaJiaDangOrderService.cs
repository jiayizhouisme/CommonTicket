using Core.Cache;
using Core.Utill.UniqueCode;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票Order.Entity;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace 通用订票.大景区.Service
{
    [Injection(Order = 0)]
    public class MaJiaDangOrderService : DefaultOrderService, ITransient
    {
        private ILogger _log { get; set; }

        public MaJiaDangOrderService(ITradeNoGenerater<long> tradeNoGenerate,IRepository<Core.Entity.Order, MasterDbContextLocator> _dal, ICacheOperation cache, ILoggerFactory logger) : base(tradeNoGenerate,_dal, cache)
        {
            _log = logger.CreateLogger("MaJiaDangOrder");
        }

        public override Task<Core.Entity.Order> CreateOrder(string objectId, string name,int day, decimal amount, string extraInfo = null)
        {
            _log.Log(LogLevel.Information, "大景区订单开始下单");
            return base.CreateOrder(objectId, name + "大景区",day, amount, extraInfo);
        }

    }
}