using 通用订票.Application.System.Services.IService;

namespace 通用订票.Application.System.IService.Factory
{
    public interface IServiceFactory
    {
        public IMyOrderServices GetOrderService(INamedServiceProvider<IMyOrderServices> _orderProvider);
        public IAppointmentService GetStockService(INamedServiceProvider<IAppointmentService> _stockProvider);
        public IMyTicketService GetTicketService(INamedServiceProvider<IMyTicketService> _ticketProvider);
    }
}
