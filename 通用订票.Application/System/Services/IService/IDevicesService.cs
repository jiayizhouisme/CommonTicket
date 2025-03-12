using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using Core.Services;

namespace 通用订票.Application.System.Services.IService
{
    public interface IDevicesService : IBaseService<Devices>
    {
        public Task<ICollection<Devices>> GetDeviceBySn(string sn);
    }
}
