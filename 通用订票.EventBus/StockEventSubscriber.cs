using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.EventBus;
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
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;

namespace 通用订票.EventBus
{
    public class StockEventSubscriber : IEventSubscriber,ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly ILogger<StockEventSubscriber> _logger;
        private readonly IEventPublisher eventPublisher;
        public StockEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<StockEventSubscriber> logger,
            IEventPublisher eventPublisher)
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;
            this.eventPublisher = eventPublisher;

        }

        /// <summary>
        /// 下单之前事件，基本就是验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [EventSubscribe("BeforeCreateOrder")]
        public async Task BeforeCreateOrder(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (BeforeCreateOrder)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();

            var s_service = factory.GetStockService(_stockProvider);

            s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
            #endregion

            var ret = await s_service.SaleStock(data.appid,data.count); //检查库存
            if (ret != null)
            {
                //成功
                CreateOrder orderCreate = new CreateOrder() {
                    id = ret.id,
                    price = data.price * data.count,
                    tenantId = data.tenantId,
                    userId = data.userId,
                    count = data.count,
                    app = ret,
                    ids = data.ids
                };
                await eventPublisher.PublishAsync(new OrderCreateEvent(orderCreate)); //给事件总线发消息
            }
            else
            {
                //失败
            }

            await Task.CompletedTask;
        }

        [EventSubscribe("OrderClose")]
        [EventSubscribe("OrderCreateFail")]
        public async Task OrderCreateFail(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OrderCreateFail)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();

            var s_service = factory.GetStockService(_stockProvider);

            s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
            #endregion

            var ret = await s_service.SaleStock(data.app.id, -data.count); //检查库存
            await s_service.DelStockFromCache(data.app.id);
        }
    }
}
