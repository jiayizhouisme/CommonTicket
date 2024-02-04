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
        public StockEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<StockEventSubscriber> logger)
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;

        }
        [EventSubscribe("OnOrderClosed")]
        public async Task OnOrderClosed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnOrderClosed)todo.Payload;

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
            var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();

            var s_service = factory.GetStockService(_stockProvider);
            var t_service = factory.GetTicketService(_ticketProvider);

            s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
            t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenantId);
            #endregion

            var tickets = await t_service.GetTickets(data.order.trade_no);
            var ret = await s_service.SaleStock(data.order.objectId, -tickets.Count); //检查库存
        }

        [EventSubscribe("OnOrderCreateFail")]
        public async Task OnOrderCreateFail(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnOrderCreateFail)todo.Payload;

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
