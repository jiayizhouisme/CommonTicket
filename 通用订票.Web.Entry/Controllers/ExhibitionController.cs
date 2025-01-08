using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Web.Entry.Model;

namespace 通用订票.Web.Entry.Controllers
{
    /// <summary>
    /// 景区控制器
    /// </summary>
    public class ExhibitionController : IDynamicApiController
    {
        private readonly IExhibitionService _exhibitionService;
        private readonly IDefaultAppointmentService _defaultAppointmentService;
        public ExhibitionController(IExhibitionService _exhibitionService, IDefaultAppointmentService defaultAppointmentService)
        {
            this._exhibitionService = _exhibitionService;
            _defaultAppointmentService = defaultAppointmentService;
        }

        /// <summary>
        /// 配置开放规则
        /// </summary>
        /// <param name="exhibition"></param>
        /// <returns></returns>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpPost(Name = "ConfigRule")]
        public async Task ConfigRule(ExhibitionRuleAddModel rule)
        {
            var ex = await this._exhibitionService.GetQueryable(a => a.id == rule.id).FirstOrDefaultAsync();
            ex.forbiddenRule = JsonConvert.SerializeObject(rule.rule);
            await this._exhibitionService.UpdateNow(ex);
        }

        /// <summary>
        /// 添加景区
        /// </summary>
        /// <param name="exhibition"></param>
        /// <returns></returns>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpPost(Name = "Add")]
        public async Task<Exhibition> AddExhibitions(Exhibition exhibition)
        {
            return await this._exhibitionService.AddExhibition(exhibition);
        }

        /// <summary>
        /// 更新景区
        /// </summary>
        /// <param name="exhibition"></param>
        /// <returns></returns>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpPost(Name = "Update")]
        public async Task<Exhibition> UpdateExhibitions(Exhibition exhibition)
        {
            var _ex = await _exhibitionService.GetExhibitionByID(exhibition.id);
            var ex = await this._exhibitionService.UpdateExhibition(exhibition);
            var apps = await _defaultAppointmentService.GetWithCondition(a => a.objectId == exhibition.id);
            foreach (var app in apps)
            {
                if (exhibition.totalAmount != ex.totalAmount)
                {
                    app.amount = ex.totalAmount;
                }
                if (exhibition.beforeDays >= 0 && exhibition.beforeDays != _ex.beforeDays)
                {
                    app.day += exhibition.beforeDays - _ex.beforeDays;
                }
            }
            await _defaultAppointmentService.UpdateNow(apps);
            return ex;
        }

        /// <summary>
        /// 删除景区
        /// </summary>
        /// <param name="id"></param>
        /// <param name="real"></param>
        /// <returns></returns>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpGet(Name = "Delete")]
        public async Task<bool> DeleteExhibitions([FromQuery] Guid id, [FromQuery] bool real = false)
        {
            return await this._exhibitionService.DeleteExhibition(id, real);
        }

        /// <summary>
        /// 获取景区
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //[Authorize]
        //[TypeFilter(typeof(SaaSAuthorizationFilter))]
        //[TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "Get")]
        public async Task<object> GetExhibitions([FromQuery]int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return await _exhibitionService.GetQueryableNt(a => a.isDeleted == false).OrderByDescending(a => a.createTime)
                .Select(a => new  {id = a.id,basicPrice = a.basicPrice,beforeDays = a.beforeDays,
                name = a.name,imgs = a.imgs})
                .ToPagedListAsync(pageIndex,pageSize);
        }

        /// <summary>
        /// 获取景区列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize]
        [NonUnify]
        [HttpGet(Name = "GetExhibitionList")]
        public async Task<object> GetExhibitionList([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return await _exhibitionService.GetQueryableNt(a => a.isDeleted == false).OrderByDescending(a => a.createTime)
                .ToPagedListAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// 获取景区
        /// </summary>
        /// <returns></returns>
        [NonUnify]
        [HttpGet(Name = "GetExhibitionById")]
        public async Task<object> GetExhibitionById([FromQuery] Guid id)
        {
            return (await _exhibitionService.GetWithConditionNt(a => a.isDeleted == false && a.id == id)).FirstOrDefault();
        }
    }
}
