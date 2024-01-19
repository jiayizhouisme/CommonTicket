﻿using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 订票系统.Rules.IService;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.BaseEntity;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    [Injection(Order = 1)]
    public class AppointmentService : StockBaseService<Appointment>, IAppointmentService,ITransient
    {
        private Guid userId;
        private MyBeetleX _cache;
        public AppointmentService(IRepository<Appointment> _dal,MyBeetleX _cache) : base(_dal, _cache)
        {
            this._cache = _cache;
        }

        public override async Task<Appointment> SaleStock(Guid stockId, int count = 1)
        {
            Guid lockerId = Guid.NewGuid();
            try
            {
                await _cache.Lock("StockUpdateLocker" + stockId, lockerId);
                var stock = await base.SaleStock(stockId, count);

                if (stock.sale > stock.amount || stock.sale < 0)
                {
                    return null;
                }
                stock.exhibition = null;
                await this.UpdateNow(stock);
                await SetStockToCache(stock);
                await _cache.ReleaseLock("StockUpdateLocker" + stockId, lockerId.ToString());
                return stock;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await _cache.ReleaseLock("StockUpdateLocker" + stockId, lockerId.ToString());
            }
        }

        public override async Task<Appointment> checkStock(Guid stockId)
        {
            var result = await base.checkStock(stockId);
            var vaild = this.vaildStock(result);
            if (vaild == true)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public virtual void SetUserContext(Guid userId)
        {
            this.userId = userId;
        }

        /// <summary>
        /// 队列之前进行基本判断
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        protected virtual bool vaildStock(Appointment stock)
        {
            var datenow = DateTime.Now;
            var timenow = DateTime.Parse(datenow.ToShortTimeString());
            var stockLimTime = DateTime.Parse(stock.endTime.ToShortTimeString());

            if (stock.day == 0 && timenow.CompareTo(stockLimTime) > 0)
            {
                return false;
            }

            if (stock.sale >= stock.amount)
            {
                return false;
            }
            return true;
        }

        public virtual async Task<Appointment> GetAppointmentById(Guid appid)
        {
            var appCache = await base.GetStockFromCache(appid.ToString());
            if (appCache != null)
            {
                return appCache;
            }

            var result = await base.GetStockFromDb(appid);
            await SetStockToCache(result);
            return result;
        }

        public virtual async Task<IQueryable<Appointment>> GetAppointmentsByDay(Guid exhibitionID,int day)
        {
            return this._dal.Where(a => a.objectId == exhibitionID && a.day < day).AsNoTracking();
        }
        
        public virtual async Task<IQueryable<Appointment>> GetAppointmentsByDate(Guid exhibitionID, DateTime date)
        {
            var day = date.Date.Subtract(DateTime.Now.Date).TotalDays;
            var entity = this._dal.Where(a => a.objectId == exhibitionID && a.day == day).AsNoTracking();
            return entity; 
        }

        public virtual async Task RefreshAppoints(Guid exhibitionID)
        {
            var query = this.GetQueryableNt(a => a.objectId == exhibitionID).OrderBy(a => a.day);
            if (await query.CountAsync() == 0)
            {
                return;
            }

            var zero = await query.Where(a => a.day == 0).Select(a => new { a.id,a.day,a.sale }).ToArrayAsync();
            var notZero = await query.Where(a => a.day != 0).Select(a => new { a.id, a.day, a.sale }).ToArrayAsync();
            for(int i = 0;i < zero.Length;i++)
            {
                await RefreshAppoint(zero[i].id, notZero[notZero.Length - 1].day,0);
            }
            
            for (int i = 0; i < notZero.Length; i++)
            {
                await RefreshAppoint(notZero[i].id, notZero[i].day - 1, notZero[i].sale);
            }
        }

        private async Task RefreshAppoint(Guid id,int day,int sale)
        {
            Guid lockerId = Guid.NewGuid();
            try
            {
                await _cache.Lock("StockUpdateLocker" + id, lockerId);
                var app = await this.GetAppointmentById(id);
                app.day = day;
                if (sale == 0) {
                    app.sale = 0;
                }
                await this.UpdateNow(app);
                await this.DelStockFromCache(id);
            }
            catch (Exception e)
            {
                await this.DelStockFromCache(id);
            }
            finally
            {
                await _cache.ReleaseLock("StockUpdateLocker" + id, lockerId.ToString());
            }
        }
    }
}
