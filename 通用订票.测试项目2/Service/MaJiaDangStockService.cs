using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;

namespace 通用订票.测试项目1.Service
{
    [Injection(Order = 0)]
    public class MaJiaDangStockService : DefaultAppointmentService, ITransient
    {
        public MaJiaDangStockService(IRepository<Appointment> _dal, ICacheOperation _cache) : base(_dal, _cache)
        {
        }
    }
}