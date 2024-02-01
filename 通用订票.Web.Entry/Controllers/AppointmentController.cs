using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    public class AppointmentController : IDynamicApiController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IExhibitionService _exhibitionService;

        public AppointmentController(IExhibitionService _exhibitionService,
            INamedServiceProvider<IAppointmentService> _stockProvider,
            IHttpContextUser httpContextUser)
        {
            this._exhibitionService = _exhibitionService;

            var factory = SaaSServiceFactory.GetServiceFactory(httpContextUser.TenantId);
            this._appointmentService = factory.GetStockService(_stockProvider);
        }

        [HttpPost]
        [HttpPost(Name = "AddAppointments")]
        public async Task AddAppointments(AppointmentAdd appointment)
        {
            var exhibition = await _exhibitionService.GetQueryableNt(a => a.id == appointment.exhibitionID).FirstOrDefaultAsync();
            if (exhibition == null)
            {
                throw new Exception("参数错误");
            }
            for (int i = 0;i < appointment.totalDay;i++)
            {
                Appointment ap = new Appointment();
                ap.id = Guid.NewGuid();
                ap.day = appointment.dayStart + i;
                ap.createTime = DateTime.Now;
                ap.startTime = DateTime.Parse(appointment.timeStart.ToString());
                ap.endTime = DateTime.Parse(appointment.timeEnd.ToString());
                ap.amount = 10000;
                ap.sale = 0;
                ap.stockName = exhibition.name;
                ap.objectId = exhibition.id;
                await _appointmentService.Add(ap);
            }
        }

        [TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "GetAppointmentsList")]
        public async Task<PagedList> GetAppointmentsList([FromQuery]Guid exhibitionID, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 0)
        {
            List<dynamic> result = new List<dynamic>();
            var before = this._appointmentService.GetQueryableNt(a => a.objectId == exhibitionID);
            var r = await before.GroupBy(a => a.day).OrderBy(a => a.Key).Select(a => a.Key).ToPagedListAsync(pageIndex,pageSize);
            PagedList pl = new PagedList();
            pl.Items = result;
            DateTime now = DateTime.Now.Date;
            foreach (var day in r.Items)
            {
                var count = await before.Where(a => a.day == day).CountAsync();
                result.Add((new { day, timesCount = count,date = now.AddDays(day).ToShortDateString() }));
                pl.HasNextPages = r.HasNextPages;
                pl.HasPrevPages = r.HasPrevPages;
                pl.TotalPages = r.TotalPages;
                pl.PageIndex = r.PageIndex;
                pl.PageSize = r.PageSize;
                pl.TotalCount = r.TotalCount;
            }
            return pl;
        }

        [TypeFilter(typeof(CacheFilter))]
        [HttpGet(Name = "Get")]
        [NonUnify]
        public async Task<List<dynamic>> GetAppointments([FromQuery] Guid FID, [FromQuery] int day = 3)
        {
            List<dynamic> result = new List<dynamic>();

            for (var _day = 0;_day < day;_day++)
            {
                var price = (await _exhibitionService.GetExhibitionByID(FID)).basicPrice;
                var _r = await this._appointmentService.GetQueryableNt(a => a.day == _day && a.objectId == FID)
                    .Select(a => new {a.amount,a.sale,a.startTime,a.endTime,a.day,a.id,total_fee = price })
                    .OrderBy(a => a.day).ThenBy(a => a.startTime).ToListAsync();
                result.Add(new {app = _r,day = _day,date = DateTime.Now.AddDays(_day).Date });
            }
            return result;
        }

        [TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "GetAppointmentByDate")]
        public async Task<object> GetAppointmentByDate([FromQuery]Guid FID, [FromQuery] DateTime date, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 20)
        {
            DateTime now = DateTime.Now;
            return await (await this._appointmentService.GetAppointmentsByDate(FID, date))
                .Select(a => new { 
                    a.day,
                    startTime = a.startTime.AddDays(a.day),
                    endTime = a.endTime.AddDays(a.day),
                    a.id})
                .ToPagedListAsync(pageIndex,pageSize);
        }
    }
}
