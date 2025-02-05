﻿using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.小景区.Service;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Services.IService;

namespace 通用订票.小景区.Factory
{
    public class ShagouServiceFactory : IServiceFactory
    {
        public IDefaultOrderServices GetOrderService(INamedServiceProvider<IDefaultOrderServices> _orderProvider)
        {
            return _orderProvider.GetService<ITransient>(nameof(ShagouOrderService));
        }

        public IDefaultAppointmentService GetStockService(INamedServiceProvider<IDefaultAppointmentService> _stockProvider)
        {
            return _stockProvider.GetService<ITransient>(nameof(ShagouStockService));
        }

        public IDefaultTicketService GetTicketService(INamedServiceProvider<IDefaultTicketService> _ticketProvider)
        {
            return _ticketProvider.GetService<ITransient>(nameof(ShagouTicketService));
        }
    }
}
