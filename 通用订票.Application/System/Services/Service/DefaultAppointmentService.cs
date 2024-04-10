using Core.Cache;
using SqlSugar;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    [Injection(Order = 1)]
    public class DefaultAppointmentService : StockBaseService<Appointment, MasterDbContextLocator>, IDefaultAppointmentService, ITransient
    {
        private Guid userId;
        private ICacheOperation _cache;
        public DefaultAppointmentService(IRepository<Appointment, MasterDbContextLocator> _dal, ICacheOperation _cache) : base(_dal, _cache)
        {
            this._cache = _cache;
        }

        public override async Task<Appointment> SaleStock(string stockId, int count = 1)
        {
            string lockerId = Guid.NewGuid().ToString();
            Appointment stock = null;
            await _cache.Lock("StockUpdateLocker" + stockId, lockerId);
            try
            {
                stock = await base.SaleStock(stockId, count);
                if (stock == null || stock.sale > stock.amount || stock.sale < 0)
                {
                    return null;
                }
                await this.UpdateNow(stock);
                await SetStockToCache(stock);
            }
            catch (Exception e)
            {
                await this.DelStockFromCache(stockId);
                throw e;
            }
            finally
            {
                await _cache.ReleaseLock("StockUpdateLocker" + stockId, lockerId);
            }
            return stock;
        }

        public override async Task<Appointment> checkStock(string stockId)
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

        public virtual async Task<Appointment> GetAppointmentById(string appid)
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

        public virtual async Task<IQueryable<Appointment>> GetAppointmentsByDay(Guid exhibitionID, int day)
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

            var zero = await query.Where(a => a.day == 0).Select(a => new { a.id, a.day, a.sale }).ToArrayAsync();
            var notZero = await query.Where(a => a.day != 0).Select(a => new { a.id, a.day, a.sale }).ToArrayAsync();
            for (int i = 0; i < zero.Length; i++)
            {
                await RefreshAppoint(zero[i].id, notZero[notZero.Length - 1].day, 0, true);
            }

            for (int i = 0; i < notZero.Length; i++)
            {
                await RefreshAppoint(notZero[i].id, notZero[i].day - 1, notZero[i].sale, false);
            }
        }

        [UnitOfWork]
        private async Task RefreshAppoint(string id, int day, int sale, bool newone)
        {
            string lockerId = Guid.NewGuid().ToString();
            try
            {
                await _cache.Lock("StockUpdateLocker" + id, lockerId);
                var app = await this.GetAppointmentById(id);
                app.day = day;

                if (sale == 0)
                {
                    app.sale = 0;
                }

                if (newone == true)
                {
                    app.createTime = DateTime.Now;
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
                await _cache.ReleaseLock("StockUpdateLocker" + id, lockerId);
            }
        }
    }
}
