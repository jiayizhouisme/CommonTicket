using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Net.Sockets;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IProcedure;
using 通用订票.Procedure.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Procedure.Procedure
{
    [Injection(Order = 0)]
    public class CreateOrderProcedure : ICreateOrderProcedure,ITransient
    {

        private IDefaultAppointmentService _appointmentService;
        private IDefaultOrderServices defaultOrderServices;
        private IDefaultTicketService _ticketService;

        private OrderCreate param;
        private Core.Entity.Order order;
        private Appointment stock;

        public virtual async Task PreloadAsync(PreloadEntity param)
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

        public virtual async Task<Core.Entity.Order> StartProcess(OrderCreate param)
        {
            var stock = await _appointmentService.SaleStock(param.appid, param.ids.Count);
            var order = await defaultOrderServices.CreateOrder(param.appid, stock.stockName, param.price * param.ids.Count);

            this.order = order;
            this.stock = stock;
            this.param = param;

            await AfterProcess();
            return order;
        }

        public virtual async Task AfterProcess()
        {
            DateTime now = DateTime.Now;
            var startTime = now.AddDays(stock.day).Date.Add(stock.startTime.TimeOfDay);
            var endTime = now.AddDays(stock.day).Date.Add(stock.endTime.TimeOfDay);
            await this._ticketService.GenarateTickets(startTime,endTime,order,param.ids.ToArray(),TicketStatus.未激活);
        }

        public Task OnExcepton(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
