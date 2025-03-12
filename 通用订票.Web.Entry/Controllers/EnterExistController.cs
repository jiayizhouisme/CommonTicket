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
    [Route("api/EnterExist")]
    [ApiController]
    /// <summary>
    /// 景区控制器
    /// </summary>
    public class EnterExistController : IDynamicApiController
    {
        private readonly IEnterExistRecordsService _enterExistRecordsService;
        public EnterExistController(IEnterExistRecordsService _enterExistRecordsService)
        {
            this._enterExistRecordsService = _enterExistRecordsService;
        }


        /// <summary>
        /// 获取景区
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator,Permissions.LocalStaff } })]
        [HttpGet(Name = "GetPaged")]
        public async Task<PagedList<EnterExistRecords>> GetPaged([FromQuery] string date = null, 
            [FromQuery] string name = null, [FromQuery] string idcard = null,
            [FromQuery]int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return await ((await _enterExistRecordsService.GetRecord(date, name, idcard)).ToPagedListAsync(pageIndex,pageSize));
        }

    }
}
