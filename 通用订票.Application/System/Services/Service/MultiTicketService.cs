using Core.Cache;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class MultiTicketService : BaseService<MultiTicket, MasterDbContextLocator>, IMultiTicketService, ITransient
    {
        private readonly ICacheOperation cache;
        public MultiTicketService(IRepository<MultiTicket, MasterDbContextLocator> rep,ICacheOperation cache)
        {
            base._dal = rep;
            this.cache = cache;
        }

        public async Task<MultiTicketCancelResult> CancelTicket(string ticket_number, int cancelCount)
        {
            MultiTicketCancelResult mr = new MultiTicketCancelResult();
            var t = await this.GetWithCondition
                (a => a.ticketNumber == ticket_number);
            var r = t.Max(a => a.usedCount);
            if (r > 0)
            {
                mr.code = 0;
                mr.message = "订单已被使用";
                mr.shouldUpdate = false;
                return mr;
            }
            foreach (var _t in t)
            {
                await DelTicketFromCache(_t.ticketNumber,_t.exhibitionId.ToString());
                if (cancelCount > _t.totalCount)
                {
                    mr.code = 0;
                    mr.message = "取消数量不正确";
                    mr.shouldUpdate = false;
                    return mr;
                }
                _t.cancelCount = cancelCount;
            }
            await this.UpdateNow(t);
            mr.code = 1;
            mr.shouldUpdate = true;
            return mr;
        }

        public async Task<ICollection<MultiTicket>> GenerateTicket(string ticket_number, string[] exhibitions, int totalCount)
        {
            foreach (var exhibition in exhibitions)
            {
                await this.Add(new MultiTicket
                {
                    exhibitionId = Guid.Parse(exhibition),
                    totalCount = totalCount,
                    ticketNumber = ticket_number,
                    cancelCount = 0,
                    usedCount = 0
                });
            }
            await this.SaveChangeNow();
            return null;
        }

        public async Task<TicketVerifyResult> CheckMultiTicket(string ticket_number, string exhibition)
        {
            TicketVerifyResult tr = new TicketVerifyResult();
            var mticket = await GetTicketFromCache(ticket_number, exhibition);
            if (mticket == null)
            {
                var t = await this.GetWithConditionNt
                (a => a.ticketNumber == ticket_number);

                mticket = t.Where(a => a.exhibitionId == Guid.Parse(exhibition)).FirstOrDefault();
                if (mticket != null)
                {
                    await SetTicketFromCache(mticket);
                }
            }

            if (mticket != null)
            {
                
                var could_use = mticket.totalCount - mticket.usedCount - mticket.cancelCount;
                if (could_use <= 0)
                {
                    tr.message = "门票已用完";
                    tr.code = 0;
                    return tr;
                }
                tr.code = 1;
                tr.message = "门票验证成功";
                return tr;
            }
            else
            {
                tr.code = 0;
                tr.message = "未找到门票";
                return tr;
            }
            
        }

        public async Task<MultiTicketVerifyResult> ConfirmCheckMultiTicket(string ticket_number, string exhibition)
        {
            MultiTicketVerifyResult tr = new MultiTicketVerifyResult();
            var mticket = await GetTicketFromCache(ticket_number, exhibition);
            if (mticket == null)
            {
                var t = await this.GetWithConditionNt
                (a => a.ticketNumber == ticket_number);

                mticket = t.Where(a => a.exhibitionId == Guid.Parse(exhibition)).FirstOrDefault();
            }

            if ((mticket.totalCount - mticket.cancelCount - mticket.usedCount) <= 0)
            {
                tr.code = 0;
                return tr;
            }
            mticket.usedCount++;
            await this.UpdateNow(mticket);
            await DelTicketFromCache(ticket_number,exhibition);
            var used = await this.GetQueryableNt(a => a.ticketNumber == ticket_number).MinAsync(a => a.usedCount);
            tr.code = 1;
            tr.usedCount = used;
            return tr;
        }

        private async Task SetTicketFromCache(MultiTicket ticket)
        {
            await cache.Set("mticket:" + ticket.ticketNumber + ":" + ticket.exhibitionId.ToString().ToLower(), ticket,600);
        }

        private async Task<MultiTicket> GetTicketFromCache(string ticket_number,string exhibitionId)
        {
            return  await cache.Get<MultiTicket>("mticket:" + ticket_number + ":" + exhibitionId.ToLower());
        }

        private async Task DelTicketFromCache(string ticket_number, string exhibitionId)
        {
            await cache.Del("mticket:" + ticket_number + ":" + exhibitionId.ToLower());
        }
    }
}
