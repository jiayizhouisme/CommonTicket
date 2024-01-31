using Core.Auth;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
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

        [NonUnify]
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<object>> Get()
        {
            this.userService.SetUserContext(Guid.Parse(httpContextUser.ID));
            return (await this.userService.GetUserInfoByUser()).Select(a => new { a.id,a.name,a.idCard,a.phoneNumber}).ToPagedList(1,5).Items;
        }

        [NonUnify]
        [HttpPost(Name = "Add")]
        public async Task<UserInfo> Add([FromBody]UserInfo userinfo)
        {
            this.userService.SetUserContext(Guid.Parse(httpContextUser.ID));
            return await this.userService.Add(userinfo);
        }
    }
}
