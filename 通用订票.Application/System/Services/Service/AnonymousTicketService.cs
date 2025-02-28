using Core.Cache;
using Core.Services;
using Core.Utill.UniqueCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class AnonymousTicketService : DefaultTicketService,IAnonymousTicketService
    {
        public AnonymousTicketService(IRepository<Ticket, MasterDbContextLocator> _dal, ICacheOperation _cache, IMultiTicketService multiTicketService)
            : base(_dal, _cache, multiTicketService)
        {

        }
        public virtual async Task<Ticket> GenarateAnonymousTickets(
            Guid exhibitionId,
            DateTime startTime,
            DateTime endTime,
            long TUserId,
            int totalCount = 1,
            string[] exhibitions = null,
            TicketStatus status = TicketStatus.未使用)
        {
            var ticket = base.GenerateTicket(startTime, endTime);
            ticket.stauts = status;
            ticket.exhibitionId = exhibitionId;
            ticket.usedCount = 0;
            ticket.totalCount = totalCount;
            ticket.isAnonymous = true;
            ticket.ota = OTAType.Normal;
            ticket.isMultiPart = false;
            ticket.TUserId = TUserId;
            ticket.QRCode = QRHelper.QRHelper.CreateQRcode("https://ticket.z2ww.com/" +
                this.GetTenant() + "/huodong/#/verification?id=" + ticket.ticketNumber);
            if (exhibitions != null)
            {
                ticket.isMultiPart = true;
                await multiTicketService.GenerateTicket(ticket.ticketNumber, exhibitions, totalCount);
            }
            else
            {
                ticket.isMultiPart = false;
            }
            await this.AddNow(ticket);

            //await SetTicketToCache(order.trade_no, result);
            //await SetTicketUserToCache(order.objectId, uids);
            return ticket;
        }
    }
}
