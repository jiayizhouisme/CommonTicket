﻿using Furion.DatabaseAccessor;
using Furion.DataEncryption.Extensions;
using Furion.LinqBuilder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.Entity;
using Core.Auth;
using 通用订票.Base.Entity;
using 通用订票.Order.Entity;
using SqlSugar;

namespace 通用订票.Application.System.Services.Service
{
    [Injection(Order = 1)]
    public class DefaultTicketService : TicketBaseService<Ticket, MasterDbContextLocator>, IDefaultTicketService, ITransient
    {
        private string userId;
        private readonly ICacheOperation _cache;
        public DefaultTicketService(IRepository<Ticket, MasterDbContextLocator> _dal, ICacheOperation _cache) : base(_dal)
        {
            this._cache = _cache;
        }

        /// <summary>
        /// 根据选择的用户数生成对应数量的门票
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="order"></param>
        /// <param name="uids"></param>
        /// <returns></returns>
        public virtual async Task<List<Core.Entity.Ticket>> GenarateTickets(
            DateTime startTime,
            DateTime endTime, OrderBase<string> order,
            int[] uids,
            TicketStatus status = TicketStatus.未激活,
            OTAType otaType = OTAType.Normal)
        {
            List<Core.Entity.Ticket> result = new List<Core.Entity.Ticket>();
            foreach (var id in uids)
            {
                var ticket = base.GenerateTicket(startTime, endTime);
                ticket.TUserId = id;
                ticket.userID = userId;
                ticket.objectId = order.trade_no;//应该替换成tradeNo
                ticket.AppointmentId = order.objectId;
                ticket.stauts = status;
                ticket.ota = otaType;
                ticket.usedCount = 0;
                ticket.totalCount = 1;
                result.Add(ticket);
            }
            try
            {
                await this.AddNow(result);
            }
            catch
            {
                throw new ArgumentException("用户不存在");
            }

            //await SetTicketToCache(order.trade_no, result);
            //await SetTicketUserToCache(order.objectId, uids);
            return result;
        }

        public virtual async Task<Ticket> GenarateTicket(DateTime startTime, DateTime endTime, OrderBase<string> order, int number, TicketStatus status, OTAType otaType = OTAType.Normal)
        {
            var ticket = base.GenerateTicket(startTime, endTime);
            ticket.TUserId = -1;
            ticket.userID = userId;
            ticket.objectId = order.trade_no;//应该替换成tradeNo
            ticket.AppointmentId = order.objectId;
            ticket.stauts = status;
            ticket.ota = otaType;
            ticket.usedCount = 0;
            ticket.totalCount = number;
            await this.AddNow(ticket);
            return ticket;
        }

        public async Task<List<Ticket>> GenarateTickets(DateTime startTime, DateTime endTime, OrderBase<string> order, int number, TicketStatus status, OTAType otaType)
        {
            List<Core.Entity.Ticket> result = new List<Core.Entity.Ticket>();
            for (int i = 0;i < number;i++)
            {
                var ticket = base.GenerateTicket(startTime, endTime);
                ticket.userID = userId;
                ticket.objectId = order.trade_no;//应该替换成tradeNo
                ticket.AppointmentId = order.objectId;
                ticket.stauts = status;
                ticket.ota = otaType;
                ticket.usedCount = 0;
                ticket.totalCount = 1;

                result.Add(ticket);
            }
            await this.AddNow(result);
            //await SetTicketToCache(order.trade_no, result);
            return result;
        }

        public virtual async Task<int> EnableTickets(ICollection<Core.Entity.Ticket> ticket)
        {
            long orderId = 0;
            foreach (var item in ticket)
            {
                var temp = await base.EnableTicket(item);
                orderId = temp.objectId;
                //await _cache.Del(GetKey(item.AppointmentId, item.TUserId));
            }
            await this.UpdateNow(ticket);
            await _cache.Del("Tickets:" + orderId);
            return 1;
        }

        public virtual async Task<int> DisableTickets(ICollection<Core.Entity.Ticket> ticket)
        {
            if (ticket == null || ticket.Count == 0)
            {
                return 0;
            }
            foreach (var item in ticket)
            {
                var temp = await base.DisableTicket(item);
                //await _cache.Del(GetKey(item.AppointmentId, item.TUserId));
            }
            await this.UpdateNow(ticket);
            //await this.DeleteNow(ticket);
            return 1;
        }
        public async Task<Ticket> GetTicket(string ticket_number)
        {
            var ticket = await _cache.Get<Ticket>("Ticket:" + ticket_number);
            if (ticket == null)
            {
                ticket = await this.GetQueryableNt(a => a.ticketNumber == ticket_number)
                .OrderByDescending(a => a.createTime).FirstOrDefaultAsync();
                await _cache.Set("Ticket:" + ticket_number,ticket,600);
            }
            return ticket;
        }

        public override async Task<Ticket> TicketCheck(Ticket ticket,int useCount = 1)
        {
            var result =  await base.TicketCheck(ticket, useCount);
            if (result != null)
            {
                await _cache.Del("Ticket:" + ticket.ticketNumber);
                await this.UpdateNow(ticket);
            }
            return result;
        }

        public virtual void SetUserContext(string user)
        {
            this.userId = user;
        }

        private async Task SetTicketUserToCache(string appointmentId, int[] uids)
        {
            foreach (var uid in uids)
            {
                await _cache.Set(GetKey(appointmentId, uid), "1", 20);
            }
        }

        private async Task SetTicketToCache(long orderId, IEnumerable<Core.Entity.Ticket> tickets)
        {
            string cacheKey = "Tickets:" + orderId;
            foreach (var item in tickets)
            {
                if (item.userID != Guid.Empty.ToString() && item.userID != null)
                {
                    await _cache.PushToList<Core.Entity.Ticket>("Tickets:" + orderId, item);
                }
            }

            //string cacheKey = "Tickets:" + orderId;
            //var list = _cache.CreateList<Core.Entity.Ticket>(cacheKey);
            //foreach (var ticket in tickets)
            //{
            //    await list.Push(ticket);
            //}

            await _cache.Expire(cacheKey, 650);
        }

        /// <summary>
        /// 仅仅判断是否重复
        /// </summary>
        /// <param name="uids"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public virtual async Task<bool> Vaild(int[] uids, Appointment appointment)
        {
            DateTime now = DateTime.Now.Date;
            var startTimeSpan = appointment.startTime.TimeOfDay;
            var endTimeSpan = appointment.endTime.TimeOfDay;
            var startTime = now.AddDays(appointment.day).Add(startTimeSpan);
            var endTime = now.AddDays(appointment.day).Add(endTimeSpan);
            foreach (var uid in uids)
            {
                var result = await _cache.Get<string>(GetKey(appointment.id, uid));
                if (result != null && result == "1")
                {
                    return false;
                }

                var anyret = await this._dal.
                    AnyAsync(a => a.TUserId == uid && startTime == a.startTime && a.endTime == endTime
                    && a.stauts != TicketStatus.已冻结);
                if (anyret == true)
                {
                    await _cache.Set(GetKey(appointment.id, uid), "1", 20);
                    return false;
                }
            }
            return true;
        }

        private string GetKey(string appointmentId, int Tuid)
        {
            return "UserId_" + userId + "Appointment_" + appointmentId + "TUserId_" + Tuid;
        }

        public virtual async Task<ICollection<Core.Entity.Ticket>> GetTickets(long orderId)
        {
            var key = "Tickets:" + orderId;
            var tickets = await _cache.GetList<Core.Entity.Ticket>(key,0);
            //var list = _cache.CreateList<Core.Entity.Ticket>(key);
            //var len = await list.Len();
            //var tickets = (await list.Range(0, (int)len)).ToList();

            if (tickets.Count > 0)
            {
                return tickets;
            }
            var result = await this.GetQueryableNt(a => a.objectId == orderId)
                .Select(a => new Core.Entity.Ticket
                {
                    _id = a._id,
                    AppointmentId = a.AppointmentId,
                    endTime = a.endTime,
                    TUserId = a.TUserId,
                    startTime = a.startTime,
                    ticketNumber = a.ticketNumber,
                    stauts = a.stauts
                })
                .ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }
            await SetTicketToCache(orderId, result);
            return result;
        }

        public override async Task AfterTicketToke(long trade_no)
        {
            await this.DelTicketsFromCache(trade_no);
        }

        private async Task DelTicketsFromCache(long trade_no)
        {
            var key = "Tickets:" + trade_no;
            await _cache.Del(key);
        }

        public async Task<Ticket> TicketCheck(string ticket_number, int useCount)
        {
            var ticket = await this.GetTicket(ticket_number);
            return await base.TicketCheck(ticket, useCount);
        }
    }
}
