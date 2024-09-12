using Core.Cache;
using Core.Services.ServiceFactory;
using DotNetCore.CAP;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Furion.TaskQueue;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;

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

       
        [EventSubscribe("OnOrderClosed")]
        public async Task Stock_OnOrderClosed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnOrderClosed)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();

            var s_service = factory.GetStockService(_stockProvider);

            s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
            #endregion

            var orderInfo = jsonSerializerProvider.Deserialize<OrderInfo>(data.order.extraInfo);
            
            try
            {
                await _cache.Lock("OrderCloseLock:" + data.order.objectId, data.order.objectId);
                var stock = await s_service.checkStock(data.order.objectId);
                stock.sale -= orderInfo.ids.Count();
                if (stock.sale < 0)
                {
                    stock.sale = 0;
                }
                await s_service.UpdateNow(stock);
                await s_service.DelStockFromCache(stock.id);
            }
            catch
            {
            }
            finally
            {
                await _cache.ReleaseLock("OrderCloseLock:" + data.order.objectId, data.order.objectId);
            }

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

            try
            {
                await _cache.Lock("OrderCloseLock:" + data.order.objectId, data.order.objectId);
                var stock = await s_service.checkStock(data.order.objectId);
                stock.sale -= orderInfo.ids.Count();
                await s_service.SaleStock(stock.id, -orderInfo.ids.Count());
                if (stock.sale < 0)
                {
                    stock.sale = 0;
                }
                await s_service.UpdateNow(stock);
                await s_service.DelStockFromCache(stock.id);
            }
            catch
            {
            }
            finally
            {
                await _cache.ReleaseLock("OrderCloseLock:" + data.order.objectId, data.order.objectId);
            }

        }
    }
}
