using Furion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.Entity;
using Core.Services;

namespace 通用订票.Application.System.Services.Service
{
    public class ExhibitionService : BaseService<Exhibition, MasterDbContextLocator>, IExhibitionService, ITransient
    {
        private readonly ICacheOperation _cache;
        public ExhibitionService(IRepository<Exhibition, MasterDbContextLocator> _dal, ICacheOperation _cache)
        {
            this._dal = _dal;
            this._cache = _cache;
        }

        public async Task<Exhibition> GetExhibitionByID(Guid id)
        {
            var appCache = await GetExhibitionFromCache(id.ToString());
            if (appCache != null)
            {
                return appCache;
            }

            var result = await GetExhibitionFromDb(id);
            if (result != null)
            {
                await SetExhibitionToCache(result);
            }
            
            return result;
        }

        private async Task<Exhibition> GetExhibitionFromDb(Guid exhibitionId)
        {
            Exhibition exhibition = null;
            exhibition = await _dal.Where(a => a.id == exhibitionId).AsNoTracking().FirstOrDefaultAsync();
            return exhibition;
        }

        private async Task<Exhibition> GetExhibitionFromCache(string exhibitionId)
        {
            var result = await _cache.Get<Exhibition>("exhibition:" + exhibitionId);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        private async Task SetExhibitionToCache(Exhibition exhibition)
        {
            try
            {
                await _cache.Set("exhibition:" + exhibition.id.ToString(), exhibition, 7200);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Exhibition> AddExhibition(Exhibition exhibition)
        {
            return await this.AddNow(exhibition);
        }

        public async Task<Exhibition> UpdateExhibition(Exhibition exhibition)
        {
            await this.UpdateNow(exhibition);
            return exhibition;
        }

        public async Task<bool> DeleteExhibition(Guid id,bool real)
        {
            var entity = await this.GetWithCondition(a => a.id == id);
            if (real == true)
            {
                var _e = entity.FirstOrDefault();
                if (_e != null)
                {
                    await this.Delete(_e);
                    return true;
                }
                return false;
            }
            else
            {
                var _e = entity.FirstOrDefault();
                if (_e != null)
                {
                    _e.isDeleted = true;
                    await this.UpdateNow(_e);
                    return true;
                }
                return false;
            }
        }
    }
}
