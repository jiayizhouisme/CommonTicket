using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Services.IService;
using 通用订票.沙沟古镇.Service;

namespace 通用订票.沙沟古镇.Factory
{
    public class ShagouServiceFactory : IServiceFactory
    {
        public IMyOrderServices GetOrderService(INamedServiceProvider<IMyOrderServices> _orderProvider)
        {
            return _orderProvider.GetService<ITransient>(nameof(ShagouOrderService));
        }

        public IAppointmentService GetStockService(INamedServiceProvider<IAppointmentService> _stockProvider)
        {
            return _stockProvider.GetService<ITransient>(nameof(ShagouStockService));
        }

        public IMyTicketService GetTicketService(INamedServiceProvider<IMyTicketService> _ticketProvider)
        {
            return _ticketProvider.GetService<ITransient>(nameof(ShagouTicketService));
        }
    }
}
