using Core.Cache;
using Core.Services;
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    /// <summary>
    /// 这是多租户模式下的配置
    /// 如果不适用多租户就在创建一个类
    /// </summary>
    public class WechatTenantMerchantConfigService : BaseService<WechatMerchantConfig, MasterDbContextLocator>
        , IWechatMerchantConfigService
    {
        private readonly ICacheOperation _cache;
        
        public WechatTenantMerchantConfigService(IRepository<WechatMerchantConfig, MasterDbContextLocator> _dal
            , ICacheOperation _cache)
        {
            this._dal = _dal;
            this._cache = _cache;
        }
        public async Task ConfigMerchantInfo(WechatMerchantConfig config)
        {
            var tenant = this._dal.Tenant;
            if (tenant != null)
            {
                string key = "MerchantConfig:" + tenant.Name;
                await _cache.Del(key);
            }
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
            var tenant = this._dal.Tenant;
            if (tenant != null)
            {
                string key = "MerchantConfig:" + tenant.Name;
                var config = await this._cache.Get<WechatMerchantConfig>(key);
                if (config != null)
                {
                    return config;
                }
                config = await this._dal.FirstOrDefaultAsync();
                await _cache.Set(key,config);
                return config;
            }
            return await this._dal.FirstOrDefaultAsync();

        }
    }
}
