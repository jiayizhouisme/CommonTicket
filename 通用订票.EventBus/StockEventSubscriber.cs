﻿using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;

namespace 通用订票.EventBus
{
    public class StockEventSubscriber : IEventSubscriber,ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly ILogger<StockEventSubscriber> _logger;
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ICacheOperation _cache;
        public StockEventSubscriber(
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

        [EventSubscribe("OnOrderRefunded")]
        public async Task Stock_OnOrderRefuned(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnOrderRefunded)todo.Payload;

            #region 获取services
            using var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();

            var s_service = factory.GetStockService(_stockProvider);

            s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
            #endregion

            var orderInfo = jsonSerializerProvider.Deserialize<OrderInfo>(data.order.extraInfo);
            await s_service.SaleStockAndUpdate(data.order.objectId, -orderInfo.ids.Count());
        }
    }
}
