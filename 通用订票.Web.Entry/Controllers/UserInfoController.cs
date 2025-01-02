using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.RemoteRequest.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Core.Entity.Specification;
using 通用订票.Web.Entry.Model;

namespace 通用订票.Web.Entry.Controllers
{
    [Route("api/userinfo")]
    /// <summary>
    /// 游客信息控制器
    /// </summary>
    public class UserInfoController : IDynamicApiController
    {
        private readonly IUserInfoService userService;
        private readonly IHttpContextUser httpContextUser;
        public UserInfoController(IUserInfoService userService, 
            IHttpContextUser httpContextUser)
        {
            this.userService = userService;
            this.httpContextUser = httpContextUser;
        }

        /// <summary>
        /// 获取游客信息
        /// </summary>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet]
        [Route("Get")]
        public async Task<IEnumerable<object>> Get()
        {
            this.userService.SetUserContext(long.Parse(httpContextUser.ID));
            return await this.userService.GetUserInfoByUser();
        }

        /// <summary>
        /// 添加游客
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpPost]
        [Route("Add")]
        public async Task<SimpleRet> Add([FromBody]UserInfo userinfo)
        {
            long id = long.Parse(httpContextUser.ID);
            int count = userService.GetQueryableNt(a => a.userID == id).Count();
            if (count >= 50000)
            {
                return SimpleRet.AddFailed();
            }
            this.userService.SetUserContext(id);
            return SimpleRet.AddSuccessed(await this.userService.Add(userinfo));
        }

        /// <summary>
        /// 编辑游客
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpPost]
        [Route("Update")]
        public async Task<SimpleRet> Update([FromBody] UserInfo userinfo)
        {
            var entity = (await this.userService.GetWithConditionNt(a => a.id == userinfo.id)).FirstOrDefault();
            long id = long.Parse(httpContextUser.ID);
            if (entity !=null && entity.userID != id)
            {
                return SimpleRet.UpdateFailed();
            }
            this.userService.SetUserContext(id);
            await this.userService.Update(userinfo);
            return SimpleRet.UpdateSuccessed(userinfo);
        }

        /// <summary>
        /// 删除游客
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet]
        [Route("Delete")]
        public async Task<SimpleRet> Delete([FromQuery] long id)
        {
            var entity = (await this.userService.GetWithCondition(a => a.id == id)).FirstOrDefault();
            if (entity == null || entity.userID != long.Parse(httpContextUser.ID))
            {
                return SimpleRet.DeleteFailed();
            }
            await this.userService.DeleteNow(entity);
            return SimpleRet.DeleteSuccessed();
        }

    }
}
