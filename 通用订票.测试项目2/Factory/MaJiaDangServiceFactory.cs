using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Services.IService;
using 通用订票.测试项目1.Service;

namespace 通用订票.测试项目1.Factory
{
    public class MaJiaDangServiceFactory : IServiceFactory
    {
        public IDefaultOrderServices GetOrderService(INamedServiceProvider<IDefaultOrderServices> _orderProvider)
        {
            return _orderProvider.GetService<ITransient>(nameof(MaJiaDangOrderService));
        }

        public IDefaultAppointmentService GetStockService(INamedServiceProvider<IDefaultAppointmentService> _stockProvider)
        {
            return _stockProvider.GetService<ITransient>(nameof(MaJiaDangStockService));
        }

        public IDefaultTicketService GetTicketService(INamedServiceProvider<IDefaultTicketService> _ticketProvider)
        {
            return _ticketProvider.GetService<ITransient>(nameof(MaJiaDangTicketService));
        }
    }
}
