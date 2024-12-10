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
                return new SimpleRet { code = 0,message = "游客数量超出限制"};
            }
            this.userService.SetUserContext(id);
            return new SimpleRet() { code = 1,message = "添加成功",data = await this.userService.Add(userinfo) };
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
                return new SimpleRet() { code = 0, message = "更新失败" };
            }
            this.userService.SetUserContext(id);
            await this.userService.Update(userinfo);
            return new SimpleRet() { code = 1, message = "更新成功", data = userinfo };
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
                return new SimpleRet() { code = 0, message = "删除失败", data = null };
            }
            await this.userService.DeleteNow(entity);
            return new SimpleRet() { code = 1, message = "删除成功" ,data = null};
        }

    }
}
