using Core.Auth;
using Core.Cache;
using Core.Services;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;

namespace 通用订票.OTA.携程.Service
{
    public class XieChengOTATicketService :
        BaseService<XieChengTicket, MasterDbContextLocator>,
        IXieChengOTATicketService
        , ITransient
    {
        private IDefaultTicketService _ticketServices { get; set; }

        public XieChengOTATicketService(
            IRepository<XieChengTicket, MasterDbContextLocator> _dal
            )
        {
            base._dal = _dal;
        }

        public void SetService(IDefaultTicketService service)
        {
            _ticketServices = service;
        }

        public async Task<Ticket> CreateTicket(XieChengOrder xiechengOrder, Core.Entity.Order order)
        {
            var startTime = DateTime.Parse(xiechengOrder.useStartDate);
            var endTime = DateTime.Parse(xiechengOrder.useEndDate);
            var ticket = await _ticketServices.GenarateTicket(startTime,
                endTime,
                order,
                xiechengOrder.quantity,
                TicketStatus.未使用,
                OTAType.XieCheng);//一张票多次
            XieChengTicket xieChengTicket = new XieChengTicket();
            xieChengTicket.ticketId = ticket._id;
            xieChengTicket.OTAPassengerId = xiechengOrder.passengerIds.Trim();
            xieChengTicket.itemId = xiechengOrder.itemId;
            await this.AddNow(xieChengTicket);
            return ticket;
        }

        public async Task<List<Ticket>> CreateTicket(XieChengOrder xiechengOrder, Core.Entity.Order order, string[] passids)
        {
            var startTime = DateTime.Parse(xiechengOrder.useStartDate);
            var endTime = DateTime.Parse(xiechengOrder.useEndDate);
            var tickets = await _ticketServices.GenarateTickets(startTime,
                    endTime,
                    order,
                    xiechengOrder.quantity,
                    TicketStatus.未使用,
                    OTAType.XieCheng);//多张票每张一次
            int i = 0;
            foreach (var ticket in tickets)
            {
                XieChengTicket xieChengTicket = new XieChengTicket();
                xieChengTicket.ticketId = ticket._id;
                xieChengTicket.OTAPassengerId = passids[i];
                xieChengTicket.itemId = xiechengOrder.itemId;
                await this.AddNow(xieChengTicket);
                i++;
            }
            return tickets;
        }
    }
}
