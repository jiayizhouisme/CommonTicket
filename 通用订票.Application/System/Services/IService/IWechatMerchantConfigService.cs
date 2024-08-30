using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IWechatMerchantConfigService : IBaseService<WechatMerchantConfig>
    {
        Task<WechatMerchantConfig> GetConfig();
        Task ConfigMerchantInfo(WechatMerchantConfig config);
    }
}
