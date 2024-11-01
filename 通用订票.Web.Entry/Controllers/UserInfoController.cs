using Core.Auth;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.Core.Entity.Specification;

namespace 通用订票.Web.Entry.Controllers
{
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
        [HttpGet(Name = "Get")]
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
        [HttpPost(Name = "Add")]
        public async Task<UserInfo> Add([FromBody]UserInfo userinfo)
        {
            int count = userService.GetQueryableNt(a => a.userID == long.Parse(httpContextUser.ID)).Count();
            if (count >= 5)
            {
                return null;
            }
            return await this.userService.Add(userinfo);
        }
    }
}
