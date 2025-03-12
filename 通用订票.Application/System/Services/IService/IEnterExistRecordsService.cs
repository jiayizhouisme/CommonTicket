using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.IService
{
    public interface IEnterExistRecordsService : IBaseService<EnterExistRecords>
    {
        Task Record(long userid, DateTime date, DeviceType type);
        Task<IQueryable<EnterExistRecords>> GetRecord(string date = null, string username = null,string idcard = null);
    }
}
