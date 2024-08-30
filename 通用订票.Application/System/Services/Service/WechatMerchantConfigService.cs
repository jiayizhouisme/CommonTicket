using Core.Cache;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class WechatMerchantConfigService : BaseService<WechatMerchantConfig, MasterDbContextLocator>
        , IWechatMerchantConfigService
    {

        private readonly ICacheOperation _cache;

        public WechatMerchantConfigService(IRepository<WechatMerchantConfig, MasterDbContextLocator> _dal
            , ICacheOperation _cache)
        {
            this._dal = _dal;
            this._cache = _cache;
        }
        public async Task ConfigMerchantInfo(WechatMerchantConfig config)
        {
            string key = "MerchantConfig";
            await _cache.Del(key);
            
            var _config = await this.Exist(a => a.appid == config.appid);
            if (_config == false)
            {
                await this.AddNow(config);
            }
            else
            {
                await this.UpdateNow(config);
            }
        }

        public async Task<WechatMerchantConfig> GetConfig()
        {
            string key = "MerchantConfig";
            var config = await this._cache.Get<WechatMerchantConfig>(key);
            if (config != null)
            {
                return config;
            }
            config = await this._dal.FirstOrDefaultAsync();
            await _cache.Set(key, config);
            return config;
        }
    }
}
