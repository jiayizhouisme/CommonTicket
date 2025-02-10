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
    public class DevicesService : BaseService<Devices, MasterDbContextLocator>, IDevicesService, ITransient
    {
        public DevicesService(IRepository<Devices, MasterDbContextLocator> _dal)
        {
            this._dal = _dal;
        }
        public async Task<string> GetExhibitionIdBySn(string sn)
        {
            return this._dal.Where(a => a.deviceSn == sn).Select(a => a.exhibitionId).FirstOrDefault();
        }
    }
}
