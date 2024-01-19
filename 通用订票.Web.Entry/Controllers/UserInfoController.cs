using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DataValidation;
using Furion.DynamicApiController;
using Furion.TaskQueue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using Core.Cache;
using 通用订票.Core.Entity;
using 通用订票.Stock.Entity;
using Core.Auth;

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
