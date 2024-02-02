using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IProcedure;
using 通用订票.Procedure.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;
using 通用订票Order.Entity;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using ProtoBuf.Serializers;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Application.System.Factory.Service;
using Microsoft.Extensions.DependencyInjection;

namespace 通用订票.Procedure.Procedure
{
    public class CloseOrderProcedure : ICloseOrderProcedure,ITransient
    {
        private IDefaultAppointmentService _appointmentService;
        private IDefaultOrderServices defaultOrderServices;
        private IDefaultTicketService _ticketService;
        public async Task PreloadAsync(PreloadEntity param)
        {
            var factory = SaaSServiceFactory.GetServiceFactory(param.TenantId);
            #region 获取services
            var _stockProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
            var _orderProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
            var _ticketProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();

            var _appointmentService = factory.GetStockService(_stockProvider);
            var defaultOrderServices = factory.GetOrderService(_orderProvider);
            var _ticketService = factory.GetTicketService(_ticketProvider);

            _appointmentService = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>
                (param.Scope.ServiceProvider, _appointmentService, param.TenantId);
            defaultOrderServices = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>
                (param.Scope.ServiceProvider, defaultOrderServices, param.TenantId);
            _ticketService = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Core.Entity.Ticket>
                (param.Scope.ServiceProvider, _ticketService, param.TenantId);
            #endregion
        }

        public async Task<Core.Entity.Order> StartProcess(OrderClose param)
        {
            var order = await defaultOrderServices.GetOrderById(param.trade_no);
            if (order.status != OrderStatus.未付款)
            {
                throw new Exception("状态不知支付");
            }
            order = await this.defaultOrderServices.CancelOrder(order);
            var tickets = await _ticketService.GetTickets(param.trade_no);
            await _ticketService.DisableTickets(tickets);
            await _appointmentService.SaleStock(param.app.id, -tickets.Count);
            return order;
        }

        public Task AfterProcess()
        {
            throw new NotImplementedException();
        }


        public Task OnExcepton(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
