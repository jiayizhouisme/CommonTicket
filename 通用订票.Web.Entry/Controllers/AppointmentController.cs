using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;
using 通用订票.Web.Entry.Model;

namespace 通用订票.Web.Entry.Controllers
{
    public class AppointmentController : IDynamicApiController
    {
        private readonly IDefaultAppointmentService _appointmentService;
        private readonly IExhibitionService _exhibitionService;

        public AppointmentController(IExhibitionService _exhibitionService,
            INamedServiceProvider<IDefaultAppointmentService> _stockProvider,
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
                ap.id = Guid.NewGuid().ToString();
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
            Exhibition exhibition = await _exhibitionService.GetExhibitionByID(FID);
            var price = exhibition.basicPrice;

            for (var _day = exhibition.beforeDays; _day < day + exhibition.beforeDays; _day++)
            {
                var _r = await this._appointmentService
                    .GetQueryableNt(a => a.day == _day && a.objectId == FID)
                    .Select(a => new {a.amount,a.sale,a.startTime,a.endTime,a.day,a.id,total_fee = price })
                    .OrderBy(a => a.day)
                    .ThenBy(a => a.startTime)
                    .ToListAsync();
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
                    a.id,
                    a.sale
                })
                .ToPagedListAsync(pageIndex,pageSize);
        }

        [HttpGet("GetAviliableDate")]
        [NonUnify]
        [TypeFilter(typeof(CacheFilter))]
        public async Task<ICollection<AppointmentEasyModel>> GetAviliableDate([FromQuery] Guid FID)
        {
            var exhibtion = await _exhibitionService.GetExhibitionByID(FID);
            var rule = exhibtion.GetForbiddenRule();
            var dates = await _appointmentService.GetQueryableNt(a => a.objectId == FID)
                .Select(a => new AppointmentEasyModel { 
                    price = exhibtion.basicPrice, 
                    date = DateTime.Now.AddDays(a.day).Date,
                    salesLeft = a.amount - a.sale
                }).OrderBy(a => a.date).ToArrayAsync();

            var group = dates.GroupBy(a => a.date);
            AppointmentEasyModel[] models = new AppointmentEasyModel[group.Count()];
            int i = 0;
            foreach (var model in group)
            {
                var date = model.Key;
                var sales = model.Sum(a => a.salesLeft);
                models[i] = new AppointmentEasyModel {
                    price = exhibtion.basicPrice,
                    date = date,
                    salesLeft = sales,
                    available = true
                };
                
                if (models[i].salesLeft <= 0)
                {
                    models[i].available = false;
                    models[i].closeReason = CloseReason.票已售空;
                }
                i++;
            }

            if (rule == null)
            {
                return models;
            }

            for (i = 0;i < models.Length;i++)
            {
                if (rule.IsDateVaild(models[i].date) == false)
                {
                    models[i].closeReason = CloseReason.展馆关闭;
                    models[i].available = false;
                }
            }

            return models;
        }

        [HttpGet(Name = "Test")]
        public async Task Test()
        {
            for (int i = 0; i < 90; i++)
            {
                Appointment app = new Appointment();
                app.id = Guid.NewGuid().ToString();
                app.stockName = "成人票";
                app.amount = 10000;
                app.sale = 0;
                app.startTime = DateTime.Parse("1999-01-01 00:00:00.0000000");
                app.endTime = DateTime.Parse("1999-01-01 23:59:59.0000000");
                app.createTime = DateTime.Now;
                app.isDeleted = false;
                app.allday = true;
                app.objectId = Guid.Parse("eafb3cdf-bf8a-4963-bffe-fb2300e929fa");
                app.day = i;
                await this._appointmentService.Add(app);
            }
            await this._appointmentService.SaveChangeNow();
        }
    }
}
