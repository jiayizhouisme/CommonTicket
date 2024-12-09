using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;
using 通用订票.Web.Entry.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet(Name = "DeleteAppointment")]
        public async Task DeleteAppointment([FromQuery]Guid id)
        {
            var appointment = (await this._appointmentService.GetWithCondition(a => a.id == id.ToString())).FirstOrDefault();
            if (appointment != null)
            {
                await this._appointmentService.DeleteNow(appointment);
            }
        }

        [HttpGet(Name = "DeleteByDay")]
        public async Task DeleteByDay([FromQuery] Guid exid, [FromQuery] int day)
        {
            var appointment = (await this._appointmentService.GetWithCondition(a => a.objectId == exid && a.day == day));
            if (appointment.Count > 0)
            {
                await this._appointmentService.DeleteNow(appointment);
            }
        }

        [HttpPost]
        [HttpPost(Name = "UpdateAppointment")]
        public async Task UpdateAppointment(AppointmentUpdateModel appointment)
        {
            var app = await this._appointmentService.GetQueryable(a => a.id == appointment.id).FirstOrDefaultAsync();
            if (app != null)
            {
                app.endTime = appointment.timeEnd;
                app.startTime = appointment.timeStart;
                await this._appointmentService.UpdateNow(app);
            }
        }

        /// <summary>
        /// 添加时间段
        /// </summary>
        /// <param name="appointment">时间段模型</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost(Name = "AddAppointment")]
        public async Task AddAppointment(AppointmentAdd appointment)
        {
            var exhibition = await _exhibitionService.GetQueryableNt(a => a.id == appointment.exhibitionID).FirstOrDefaultAsync();
            if (exhibition == null)
            {
                throw new Exception("参数错误");
            }
            foreach (var spans in appointment.timeSpans)
            {
                Appointment ap = new Appointment();
                ap.id = Guid.NewGuid().ToString();
                ap.day = appointment.day;
                ap.createTime = DateTime.Now;
                ap.startTime = spans.timeStart;
                ap.endTime = spans.timeEnd;
                ap.amount = exhibition.totalAmount;
                ap.sale = 0;
                ap.objectId = exhibition.id;
                await _appointmentService.Add(ap);
            }
        }

        /// <summary>
        /// 批量添加时间段
        /// </summary>
        /// <param name="appointment">时间段模型</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost(Name = "AddAppointments")]
        public async Task AddAppointments(AppointmentsAdd appointment)
        {
            var exhibition = await _exhibitionService.GetQueryableNt(a => a.id == appointment.exhibitionID).FirstOrDefaultAsync();
            if (exhibition == null)
            {
                throw new Exception("参数错误");
            }
            for (int i = 0;i <= appointment.totalDay;i++)
            {
                foreach (var spans in appointment.timeSpans)
                {
                    Appointment ap = new Appointment();
                    ap.id = Guid.NewGuid().ToString();
                    ap.day = appointment.dayStart + i + exhibition.beforeDays;
                    ap.createTime = DateTime.Now;
                    ap.startTime = spans.timeStart;
                    ap.endTime = spans.timeEnd;
                    ap.amount = exhibition.totalAmount;
                    ap.sale = 0;
                    ap.objectId = exhibition.id;
                    await _appointmentService.Add(ap);
                }
            }
        }

        /// <summary>
        /// 获取时间段列表（详情）
        /// </summary>
        /// <param name="exhibitionID">景区id</param>
        /// <param name="pageIndex">分页</param>
        /// <param name="pageSize">分页</param>
        /// <returns></returns>
        [NonUnify]
        [HttpGet(Name = "GetAppointmentsListDetail")]
        public async Task<object> GetAppointmentsListDetail([FromQuery] Guid exhibitionID)
        {
            List<dynamic> result = new List<dynamic>();
            var before = await this._appointmentService.GetQueryableNt(a => a.objectId == exhibitionID).Select(a =>
                new { a.amount, a.sale, a.startTime, a.endTime, a.day, a.id })
                    .OrderBy(a => a.day)
                    .ThenBy(a => a.startTime).ToListAsync();
            if (before.IsNullOrEmpty())
            {
                return result;
            }
            int r = before.Max(a => a.day);
            int r1 = before.Min(a => a.day);
            DateTime now = DateTime.Now.Date;
            for(int i = r1; i < r;i++)
            {
                var list = before.Where(a => a.day == i).ToList();
                result.Add((new { day = i, app = list, date = now.AddDays(i).ToShortDateString() }));
            }
            return result;
        }

        /// <summary>
        /// 获取时间段列表
        /// </summary>
        /// <param name="exhibitionID">景区id</param>
        /// <param name="pageIndex">分页</param>
        /// <param name="pageSize">分页</param>
        /// <returns></returns>
        //[TypeFilter(typeof(CacheFilter))]
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

        /// <summary>
        /// 根据day获取往后day个天可预约时间段
        /// </summary>
        /// <param name="FID">景区id</param>
        /// <param name="day">要获取多少天，传入3表示获取今天往后3天的时间段</param>
        /// <returns></returns>
        //[TypeFilter(typeof(CacheFilter))]
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

        /// <summary>
        /// 根据日期获取那一天可用时间段
        /// </summary>
        /// <param name="FID">景区id</param>
        /// <param name="date">日期</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //[TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "GetAppointmentByDate")]
        public async Task<object> GetAppointmentByDate([FromQuery]Guid FID, [FromQuery] DateTime date)
        {
            var exhibition = await _exhibitionService.GetExhibitionByID(FID);

            DateTime now = DateTime.Now;
            return (await this._appointmentService.GetAppointmentsByDate(FID, date))
                .Select(a => new
                {
                    a.day,
                    a.startTime,
                    a.endTime,
                    a.id,
                    a.sale,
                    amount = a.amount - a.sale,
                    exhibition.basicPrice
                });
        }

        /// <summary>
        /// 获取景区所有可用的日期
        /// </summary>
        /// <param name="FID">景区ID</param>
        /// <returns></returns>
        [HttpGet("GetAviliableDate")]
        [NonUnify]
        //[TypeFilter(typeof(CacheFilter))]
        public async Task<ICollection<AppointmentEasyModel>> GetAviliableDate([FromQuery] Guid FID)
        {
            var exhibtion = await _exhibitionService.GetExhibitionByID(FID);
            if (exhibtion == null)
            {
                return null;
            }
            var rule = exhibtion.GetForbiddenRule();
            var dates = await _appointmentService.GetQueryableNt(a => a.objectId == FID)
                .Select(a => new AppointmentEasyModel { 
                    price = exhibtion.basicPrice, 
                    date = DateTime.Now.AddDays(a.day).Date,
                    salesLeft = a.amount - a.sale
                }).OrderBy(a => a.date).ToArrayAsync();

            var group = dates.GroupBy(a => a.date);
            var first = group.FirstOrDefault();
            if (first == null)
            {
                return null;
            }
            var _firstMonth = first.Key;
            var firstMonth = _firstMonth.AddDays(-_firstMonth.Day + 1);
            var lastMonth = group.LastOrDefault().Key;
            int lastMonthCount = DateTime.DaysInMonth(lastMonth.Year,lastMonth.Month) - lastMonth.Day;
            
            AppointmentEasyModel[] models = new AppointmentEasyModel[group.Count() + _firstMonth.Day - 1 + lastMonthCount];

            int i;
            for (i = 0;i < _firstMonth.Day - 1;i++)
            {
                models[i] = new AppointmentEasyModel
                {
                    price = exhibtion.basicPrice,
                    date = firstMonth.AddDays(i),
                    salesLeft = 0,
                    available = false,
                    closeReason = CloseReason.已结束
                };
            }

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
                    models[i].closeReason = CloseReason.已约完;
                }
                i++;
            }
            for (int j = 1; i < models.Count(); i++,j++)
            {
                models[i] = new AppointmentEasyModel
                {
                    price = exhibtion.basicPrice,
                    date = lastMonth.AddDays(j),
                    salesLeft = 0,
                    available = false,
                    closeReason = CloseReason.未开放
                };
            }
            if (rule == null)
            {
                return models;
            }

            for (i = 0;i < models.Length;i++)
            {
                if (rule.IsDateVaild(models[i].date) == false)
                {
                    models[i].closeReason = CloseReason.未开放;
                    models[i].available = false;
                }
            }

            return models;
        }

    }
}
