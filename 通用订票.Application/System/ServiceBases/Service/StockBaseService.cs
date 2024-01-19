﻿using BeetleX.Redis.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 订票系统.Rules.IService;
using 通用订票.Application.System.ServiceBases.IService;
using Core.Services;
using Core.Cache;
using 通用订票.Core.BaseEntity;
using 通用订票.Core.Entity;
using 通用订票.Stock.Entity;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public abstract class StockBaseService<T> : BaseService<T>, IStockService<T> where T : Core.BaseEntity.Stock, new()
    {
        private readonly MyBeetleX _cache;
        private long lo = 0;

        public StockBaseService(IRepository<T> _dal, MyBeetleX _cache)
        {
            this._dal = _dal;
            this._cache = _cache;
        }

        public virtual async Task<T> checkStock(Guid stockId)
        {
            T stock = null;

            stock = await GetStockFromCache(stockId.ToString());
            if (stock != null)
            {
                return stock;
            }

            string lockUUid = Guid.NewGuid().ToString();
            lo = await _cache.Lock("StockUpdateLocker" + stockId.ToString(), lockUUid);
            try
            {
                stock = await GetStockFromCache(stockId.ToString());
                if (stock != null)
                {
                    await _cache.ReleaseLock("StockUpdateLocker" + stockId.ToString(), lockUUid);
                    return stock;//再判断一次
                }
                stock = await GetStockFromDb(stockId);
                if (stock != null)
                {
                    await SetStockToCache(stock);
                    
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                await _cache.ReleaseLock("StockUpdateLocker" + stockId.ToString(), lockUUid);
            }
            return stock;//再判断一次
        }

        public virtual async Task<T> SaleStock(Guid stockId, int count = 1)
        {
            T stock = null;
            stock = await GetStockFromCache(stockId.ToString());
            if (stock == null)
            {
                stock = await GetStockFromDb(stockId);
            }
            
            stock.sale = stock.sale + count;

            return stock;
        }

        protected async Task<T> GetStockFromDb(Guid stockId)
        {
            T stock = null;
            stock = await _dal.Where(a => a.id == stockId).AsNoTracking().FirstOrDefaultAsync();
            return stock;
        }

        protected async Task<T> GetStockFromCache(string stockId)
        {
            var result = await _cache.Get<T>("stock:" + stockId);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        protected async Task SetStockToCache(T stock)
        {
            try
            {
                await _cache.Set("stock:" + stock.id.ToString(), stock, 7200);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task DelStockFromCache(Guid stockId)
        {
            await _cache.Del("stock:" + stockId.ToString());
        }
    }
}
