using Core.Services;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Application.System.Services.Service
{
    public class EnterExistRecordsService : BaseService<EnterExistRecords,MasterDbContextLocator>,IEnterExistRecordsService,ITransient
    {
        public EnterExistRecordsService(IRepository<EnterExistRecords,MasterDbContextLocator> _rep)
        {
            this._dal = _rep;
        }
        public async Task Record(long userid,DateTime date,DeviceType type)
        {
            await this.AddNow(new EnterExistRecords()
            {
                recordTime = date,
                userid = userid,
                type = type
            });
        }


        public async Task<IQueryable<EnterExistRecords>> GetRecord(string date = null, string name = null, string idcard = null)
        {
            var query = this.GetQueryableNt(a => a != null).Include(a => a.userinfo).AsQueryable();
            if (!string.IsNullOrEmpty(date))
            {
                var _date = DateTime.Parse(date);
                query = query.Where( a=> a.recordTime.Date.CompareTo(_date) == 0);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.userinfo.name.Contains(name));
            }

            if (!string.IsNullOrEmpty(idcard))
            {
                query = query.Where(a => a.userinfo.idCard.Contains(idcard));
            }

            return query;
        }
    }
}
