using Core.Cache;
using Core.Services;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Core.BaseEntity;

namespace 通用订票.Application.System.ServiceBases.Service
{
    public abstract class StockBaseService<T,DbLocator> : BaseService<T,DbLocator>, IStockService<T> where T : Core.BaseEntity.Stock, new() where DbLocator : class, IDbContextLocator
    {
        private readonly ICacheOperation _cache;
        private long lo = 0;
        public StockBaseService(IRepository<T, DbLocator> _dal, ICacheOperation _cache)
        {
            this._dal = _dal;
            this._cache = _cache;
        }

        public virtual async Task<T> checkStock(string stockId)
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
            finally
            {
                await _cache.ReleaseLock("StockUpdateLocker" + stockId.ToString(), lockUUid);
            }
            return stock;//再判断一次
        }

        //public virtual async Task<T> SaleStock(string stockId, int count = 1)
        //{
        //    T stock = null;
        //    stock = await GetStockFromCache(stockId.ToString());
        //    if (stock == null)
        //    {
        //        stock = await GetStockFromDb(stockId);
        //    }
        //    if (stock != null)
        //        stock.sale = stock.sale + count;

        //    return stock;
        //}

        public virtual async Task<bool> SaleStock(string stockId, int count = 1)
        {
            T stock = null;
            stock = await GetStockFromCache(stockId.ToString());
            if (stock == null)
            {
                stock = await GetStockFromDb(stockId);
            }
            if (stock != null)
            {
                int? init = await GetSaled(stockId);
                if (init == null)
                {
                    await _cache.Lock("StockCheckLock:" + stockId, stockId);
                    init = await GetSaled(stockId);
                    if (init == null)
                    {
                        await _cache.Set("StockSales:" + stockId, stock.sale, 36000);
                    }
                    await _cache.ReleaseLock("StockCheckLock:" + stockId, stockId);
                }

                var sales = await _cache.Incrby("StockSales:" + stockId, count, 36000);
                if (sales < 0)
                {
                    await _cache.Decrby("StockSales:" + stockId, (int)sales, 36000);
                    return false;
                }
                if (sales > stock.amount)
                {
                    await _cache.Decrby("StockSales:" + stockId, count, 36000);
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        protected async Task<T> GetStockFromDb(string stockId)
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

        public async Task DelStockFromCache(string stockId)
        {
            await _cache.Del("stock:" + stockId);
        }

        public async Task<int?> GetSaled(string stockId)
        {
            return await _cache.Get<int?>("StockSales:" + stockId);
        }

        public async Task<bool> SaleStockAndUpdate(string stockId, int count)
        {
            var result = await this.SaleStock(stockId,count);
            if (result == true)
            {
                T stock = null;
                await _cache.Lock("OrderCloseLock:" + stockId, stockId);
                stock = await GetStockFromCache(stockId.ToString());
                if (stock == null)
                {
                    stock = await GetStockFromDb(stockId);
                }
                stock.sale += count;
                await this.UpdateNow(stock);
                await this.DelStockFromCache(stockId);
                await _cache.ReleaseLock("OrderCloseLock:" + stockId, stockId);
            }
            return result;

        }
    }
}
