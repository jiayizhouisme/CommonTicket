using Core.Cache;
using Core.Services.ServiceFactory;
using DotNetCore.CAP;
using Furion.DependencyInjection;
using Furion.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;

namespace 通用订票.EventBus
{
    public class TicketEventSubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly ILogger<TicketEventSubscriber> _logger;
        
        public TicketEventSubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<TicketEventSubscriber> logger)
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;
        }

        //[EventSubscribe("OnOrderCreated")]
        //public async Task Ticket_OnOrderCreated(EventHandlerExecutingContext context)
        //{
        //    var todo = context.Source;
        //    var data = (OnOrderCreated)todo.Payload;
        //    #region 获取services
        //    var scope = this.ScopeFactory.CreateScope();
        //    var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
        //    var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();

        //    var t_service = factory.GetTicketService(_ticketProvider);

        //    t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenantId);
        //    #endregion
        //    t_service.SetUserContext(data.userId);
        //    var startTime = data.order.createTime.Value.AddDays(data.app.day).Date.Add(data.app.startTime.TimeOfDay);
        //    var endTime = data.order.createTime.Value.AddDays(data.app.day).Date.Add(data.app.endTime.TimeOfDay);
        //    await t_service.GenarateTickets(startTime, endTime, data.order, data.ids.ToArray(), TicketStatus.未激活);
        //}

        [EventSubscribe("OnOrderClosed")]
        public async Task Ticket_OnOrderClosed(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (OnOrderClosed)todo.Payload;
            if (data.order.amount == 0)
            {
                return;
            }

            #region 获取services
            var scope = this.ScopeFactory.CreateScope();
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();

            var t_service = factory.GetTicketService(_ticketProvider);

            t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenantId);
            #endregion
            t_service.SetUserContext(data.userId);

            try
            {
                var tickets = await t_service.GetTickets(data.order.trade_no);
                if (tickets.Count > 0)
                {
                    await t_service.DisableTickets(tickets);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
