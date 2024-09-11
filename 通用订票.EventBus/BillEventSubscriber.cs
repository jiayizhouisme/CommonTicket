using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus
{
    public class BillEventSubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly ILogger<StockEventSubscriber> _logger;
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ICacheOperation _cache;
        public BillEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<StockEventSubscriber> logger,
            IJsonSerializerProvider jsonSerializerProvider,
            ICacheOperation _cache
            )
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this._cache = _cache;
        }

        [EventSubscribe("OnOrderClosed")]
        public async Task Bill_OnOrderClosed(EventHandlerExecutingContext context)
        {
            var closedEntity = (OnOrderClosed)context.Source.Payload;

            var scope = this.ScopeFactory.CreateScope();

            var bill_service = ServiceFactory.GetSaasService<IWechatBillService, WechatBill>(scope.ServiceProvider, closedEntity.tenantId);
            await bill_service.UpdateStatus(closedEntity.order.status,closedEntity.order.trade_no);
        }
    }
}
