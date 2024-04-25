using BeetleX.Packets;
using Core.Auth;
using Core.Cache;
using Core.Services;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.OTA.携程.Service
{
    public class XieChengOTATicketService :
        BaseService<XieChengTicket, MasterDbContextLocator>,
        IXieChengOTATicketService
        , ITransient
    {
        private IDefaultTicketService _ticketServices;
        private readonly ICacheOperation _cache;

        public XieChengOTATicketService(
            IRepository<XieChengTicket, MasterDbContextLocator> _dal,
            ICacheOperation _cache
            )
        {
            base._dal = _dal;
            this._cache = _cache;
        }

        public void SetService(IDefaultTicketService service)
        {
            _ticketServices = service;
        }

        public async Task<Ticket> CreateTicket(Exhibition exhibition, Appointment stock, XieChengOrder xiechengOrder, Core.Entity.Order order)
        {
            var startTime = order.createTime.Value.AddDays(stock.day).Date.Add(stock.startTime.TimeOfDay);
            var endTime = order.createTime.Value.AddDays(stock.day).Date.Add(stock.endTime.TimeOfDay);
            order.objectId = stock.id;
            Ticket ticket = null;
            if (exhibition.isMultiPart == false)
            {
                ticket = await _ticketServices.GenarateTicket(startTime,
                endTime,
                order,
                xiechengOrder.quantity,
                TicketStatus.未使用,
                null,
                OTAType.XieCheng);//一张票多次

            }
            else
            {
                ticket = await _ticketServices.GenarateTicket(startTime,
                endTime,
                order,
                xiechengOrder.quantity,
                TicketStatus.未使用,
                exhibition.exhibitions.Split(' '),
                OTAType.XieCheng);//一张票多次
            }
            
            XieChengTicket xieChengTicket = new XieChengTicket();
            xieChengTicket.ticketId = ticket._id;
            xieChengTicket.OTAPassengerId = xiechengOrder.passengerIds.Trim();
            xieChengTicket.itemId = xiechengOrder.itemId;
            xieChengTicket.voucherStatus = 0;
            await this.AddNow(xieChengTicket);
            
            return ticket;
        }

        public async Task<List<Ticket>> CreateTicket(Exhibition exhibition,Appointment stock, XieChengOrder xiechengOrder, Core.Entity.Order order, string[] passids)
        {
            var startTime = order.createTime.Value.AddDays(stock.day).Date.Add(stock.startTime.TimeOfDay);
            var endTime = order.createTime.Value.AddDays(stock.day).Date.Add(stock.endTime.TimeOfDay);
            order.objectId = stock.id;
            List<Ticket>? tickets = null;
            if (exhibition.isMultiPart == false)
            {
                tickets = await _ticketServices.GenarateTickets(startTime,
                    endTime,
                    order,
                    xiechengOrder.quantity,
                    TicketStatus.未使用,
                    null,
                    OTAType.XieCheng);//多张票每张一次
            }
            else
            {
                tickets = await _ticketServices.GenarateTickets(startTime,
                    endTime,
                    order,
                    xiechengOrder.quantity,
                    TicketStatus.未使用,
                    exhibition.exhibitions.Split(' '),
                    OTAType.XieCheng);//多张票每张一次
            }
                
            int i = 0;
            foreach (var ticket in tickets)
            {
                XieChengTicket xieChengTicket = new XieChengTicket();
                xieChengTicket.ticketId = ticket._id;
                xieChengTicket.OTAPassengerId = passids[i];
                xieChengTicket.itemId = xiechengOrder.itemId;
                xieChengTicket.voucherStatus = 0;
                await this.AddNow(xieChengTicket);
                i++;
            }
            return tickets;
        }

        public async Task<XieChengTIcketVerifyResult> TicketVerify(XieChengTicket xiechengTicket, int useCount = 1,string exhibitionId = null)
        {
            XieChengTIcketVerifyResult xr = new XieChengTIcketVerifyResult();
            if (xiechengTicket != null)
            {
                var ticket = xiechengTicket.ticket;
                var result = await this._ticketServices.TicketCheck(ticket,useCount,exhibitionId);
                xr.code = result.code;
                xr.message = result.message;
                xr.shouldUpdate = result.shouldUpdate;
                if (result.shouldUpdate == false)
                {
                    await _ticketServices.TicketEndCheck(xiechengTicket.ticket.ticketNumber);
                    return xr;
                }
                if (result.code == 1)
                {
                    if (ticket.usedCount == ticket.totalCount)
                    {
                        xiechengTicket.voucherStatus = 1;
                    }
                    else if (ticket.usedCount < ticket.totalCount)
                    {
                        xiechengTicket.voucherStatus = 0;
                    }
                    
                    await _cache.Del("XieChengTicket:" + xiechengTicket.ticket.ticketNumber);
                    xiechengTicket.ticket = null;
                    await this.UpdateNow(xiechengTicket);
                    xiechengTicket.ticket = ticket;
                    xr.ticket = xiechengTicket;
                }
            }
            else
            {
                xr.code = 0;
                xr.message = "未找到门票";
                xr.ticket = xiechengTicket;
            }
            await _ticketServices.TicketEndCheck(xiechengTicket.ticket.ticketNumber);
            return xr;
        }

        public async Task<XieChengTicket> GetTicket(string ticket_number)
        {
            var xiechengTicket = await _cache.Get<XieChengTicket>("XieChengTicket:" + ticket_number);
            if (xiechengTicket == null)
            {
                var ticket = await this._ticketServices.GetTicket(ticket_number);
                xiechengTicket = await this.GetQueryableNt(a => a.ticketId == ticket._id).FirstOrDefaultAsync();
                xiechengTicket.ticket = ticket;
                await _cache.Set("XieChengTicket:" + ticket_number, xiechengTicket,600);
            }
            return xiechengTicket;
        }

        public async Task<MultiTicketCancelResult> CancelTicket(string ticket_number, int cancelCount)
        {
            return await this._ticketServices.CancelMultiTicket(ticket_number, cancelCount);
        }
    }
}
