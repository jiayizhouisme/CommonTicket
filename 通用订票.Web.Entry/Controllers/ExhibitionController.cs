using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

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
        //[TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(CacheFilter))]
        [NonUnify]
        [HttpGet(Name = "Get")]
        public async Task<PagedList<Exhibition>> GetExhibitions([FromQuery]int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return await _exhibitionService.GetQueryableNt(a => a.isDeleted == false).ToPagedListAsync(pageIndex,pageSize);
        }
    }
}
