using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IProcedure;
using 通用订票.Procedure.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Procedure.Procedure
{
    public class TicketGenerateProcedure : ITicketGenerateProcedure,ITransient
    {
        private IDefaultOrderServices defaultOrderServices;
        private IDefaultTicketService _ticketService;
        public async Task PreloadAsync(PreloadEntity param)
        {
            var factory = SaaSServiceFactory.GetServiceFactory(param.TenantId);
            var _ticketProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
            var _orderProvider = param.Scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
            var _ticketService = factory.GetTicketService(_ticketProvider);
            var defaultOrderServices = factory.GetOrderService(_orderProvider);
            _ticketService = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Core.Entity.Ticket>(param.Scope.ServiceProvider, _ticketService, param.TenantId);
            defaultOrderServices = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(param.Scope.ServiceProvider, defaultOrderServices, param.TenantId);

            _ticketService.SetUserContext(param.Userid);
        }

        public async Task<ICollection<Ticket>> StartProcess(TicketCreate param)
        {
            try
            {
                var order = await defaultOrderServices.GetOrderById(param.order.trade_no);
                if (order.status != 通用订票Order.Entity.OrderStatus.已关闭 &&
                    order.status != 通用订票Order.Entity.OrderStatus.已退款 &&
                    order.status != 通用订票Order.Entity.OrderStatus.一部分退款)
                {
                    if (order.status == 通用订票Order.Entity.OrderStatus.已付款)
                    {
                        return await _ticketService.GenarateTickets(param.startTime, param.endTime, param.order, param.uid.ToArray(), TicketStatus.未使用);
                    }
                    else
                    {
                        return await _ticketService.GenarateTickets(param.startTime, param.endTime, param.order, param.uid.ToArray(), TicketStatus.未激活);
                    }
                }
            }
            catch (Exception e)
            {
                await OnExcepton(e);
                return null;
            }
            return null;
        }

        public async Task AfterProcess()
        {
            await Task.CompletedTask;
        }

        public Task OnExcepton(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
