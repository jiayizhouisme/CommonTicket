using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Services.IService;
using 通用订票.马家荡.Service;

namespace 通用订票.马家荡.Factory
{
    public class MaJiaDangServiceFactory : IServiceFactory
    {
        public IMyOrderServices GetOrderService(INamedServiceProvider<IMyOrderServices> _orderProvider)
        {
            return _orderProvider.GetService<ITransient>(nameof(MaJiaDangOrderService));
        }

        public IAppointmentService GetStockService(INamedServiceProvider<IAppointmentService> _stockProvider)
        {
            return _stockProvider.GetService<ITransient>(nameof(MaJiaDangStockService));
        }

        public IMyTicketService GetTicketService(INamedServiceProvider<IMyTicketService> _ticketProvider)
        {
            return _ticketProvider.GetService<ITransient>(nameof(MaJiaDangTicketService));
        }
    }
}
