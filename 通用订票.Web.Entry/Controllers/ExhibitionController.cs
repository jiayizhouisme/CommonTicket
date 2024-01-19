using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DataValidation;
using Furion.DynamicApiController;
using Furion.Schedule;
using Furion.TaskQueue;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.MiddelWares;
using System.Security.Claims;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using Core.Cache;
using 通用订票.Core.Entity;
using 通用订票.Stock.Entity;
using Microsoft.AspNetCore.Authorization;

namespace 通用订票.Web.Entry.Controllers
{
    public class ExhibitionController : IDynamicApiController
    {
        private readonly IUserService userService;
        private readonly IExhibitionService _exhibitionService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ExhibitionController(IUserService userService, IHttpContextAccessor contextAccessor, IExhibitionService _exhibitionService)
        {
            this.userService = userService;
            _contextAccessor = contextAccessor;
            this._exhibitionService = _exhibitionService;
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "Get")]
        public async Task<PagedList<Exhibition>> GetExhibitions([FromQuery]int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return await _exhibitionService.GetQueryableNt(a => a != null).ToPagedListAsync(pageIndex,pageSize);
        }
    }
}
