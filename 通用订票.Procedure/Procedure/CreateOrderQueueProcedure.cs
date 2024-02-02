using BeetleX.Clients;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.JsonSerialization;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Net.Sockets;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
using 通用订票.Procedure.IProcedure;
using 通用订票.Procedure.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Procedure.Procedure
{
    [Injection(Order = 1)]
    public class CreateOrderQueueProcedure : ICreateOrderProcedure,ITransient
    {
        private IDefaultAppointmentService _appointmentService;
        private IDefaultOrderServices defaultOrderServices;
        private readonly IQueuePushInfo _queue;

        private OrderCreate param;
        private Core.Entity.Order order;
        private Appointment stock;

        public CreateOrderQueueProcedure(IQueuePushInfo _queue)
        {
            this._queue = _queue;
        }

        public virtual async Task PreloadAsync(PreloadEntity param)
        {
            var factory = SaaSServiceFactory.GetServiceFactory(param.TenantId);
            #region 获取services
            var _stockProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
            var _orderProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
            var _ticketProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();

            var _appointmentService = factory.GetStockService(_stockProvider);
            var defaultOrderServices = factory.GetOrderService(_orderProvider);

            _appointmentService = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>
                (param.Scope.ServiceProvider, _appointmentService, param.TenantId);
            defaultOrderServices = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>
                (param.Scope.ServiceProvider, defaultOrderServices, param.TenantId);
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

            var CreateTickets = new TicketCreateQueueEntity(new TicketCreate()
            {
                startTime = startTime,
                endTime = endTime,
                order = order,
                tenantId = param.tenantId,
                uid = param.ids,
                userid = param.userid
            });

            await _queue.PushMessage(CreateTickets);

            var CloseOrder = new OrderCloseQueueEntity(
                new OrderClose()
                {
                    trade_no = order.trade_no,
                    app = stock,
                    delay = 10,
                    tenantId = param.tenantId
                }
                );

            await _queue.PushMessageDelay(CloseOrder, DateTime.Now.AddSeconds(60));
        }

        public Task OnExcepton(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
