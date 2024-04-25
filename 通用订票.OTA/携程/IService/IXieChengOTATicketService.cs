using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Order.IService;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.Model;
using 通用订票.Web.Entry.Controllers;

namespace 通用订票.OTA.携程.IService
{
    public interface IXieChengOTATicketService : IBaseService<XieChengTicket>
    {
        Task<Ticket> CreateTicket(Exhibition exhibition,Appointment stock, XieChengOrder xiechengOrder,Core.Entity.Order order);
        Task<List<Ticket>> CreateTicket(Exhibition exhibition, Appointment stock, XieChengOrder xiechengOrder, Core.Entity.Order order, string[] passids);
        Task<XieChengTIcketVerifyResult> TicketVerify(XieChengTicket xiechengTicket,int useCount, string exhibitionId);
        Task<XieChengTicket> GetTicket(string ticket_number);
        Task<MultiTicketCancelResult> CancelTicket(string ticket_number,int cancelCount);
        void SetService(IDefaultTicketService service);
    }
}
