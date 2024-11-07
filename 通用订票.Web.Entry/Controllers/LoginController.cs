using Core.Auth;
using Core.HttpTenant;
using Core.MiddelWares;
using Core.User.Entity;
using Furion.DataEncryption;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Furion.LinqBuilder;
using Furion.RemoteRequest.Extensions;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using 通用订票.Application.System.QRHelper;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
namespace 通用订票.Web.Entry.Controllers
{
    /// <summary>
    /// 登陆控制器
    /// </summary>
    public class LoginController : IDynamicApiController
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITenantGetSetor tenantGetSetor;
        public LoginController(IUserService userService, IHttpContextAccessor contextAccessor, ITenantGetSetor tenantGetSetor)
        {
            this.userService = userService;
            _contextAccessor = contextAccessor;
            this.tenantGetSetor = tenantGetSetor;
        }

        /// <summary>
        /// 后台管理员密码登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody]Login_Web user)
        {
            var tenant_id = tenantGetSetor.Get();
            //if (tenant_id.IsNullOrEmpty())
            //{
            //    return new UnauthorizedResult();
            //}

            var result = await userService.GetToken(user.Adapt<User>(),tenant_id);
            if (result == null)
            {
                return new UnauthorizedResult();
            }

            // 设置响应报文头
            _contextAccessor.HttpContext.Response.Headers["access-token"] = result[0];
            _contextAccessor.HttpContext.Response.Headers["x-access-token"] = result[1];
            return new OkResult();
        }

        /// <summary>
        /// 用户微信登录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpGet(Name = "WechatLogin")]
        public async Task<IActionResult> WechatLogin([FromQuery] string openid)
        {
            var tenant_id = tenantGetSetor.Get();

            try
            {
                var token = await userService.GetWechatToken(openid,tenant_id);
                // 设置响应报文头
                _contextAccessor.HttpContext.Response.Headers["access-token"] = token[0];
                _contextAccessor.HttpContext.Response.Headers["x-access-token"] = token[1];
                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [HttpGet(Name = "Logout")]
        public bool Logout()
        {
            _contextAccessor.HttpContext.Response.Headers["access-token"] = "";
            _contextAccessor.HttpContext.Response.Headers["x-access-token"] = "";
            return true;
        }

        [HttpGet]
        public async Task<User> Test()
        {
            return await userService.RegisteNewUser(new User { username = "test",password = "123"});
        }
    }
}
