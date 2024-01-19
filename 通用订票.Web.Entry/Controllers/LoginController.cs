using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DataValidation;
using Furion.DynamicApiController;
using Furion.TaskQueue;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using Core.Cache;
using 通用订票.Core.Entity;
using 通用订票.Stock.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    public class LoginController : IDynamicApiController
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginController(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            this.userService = userService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login(User user)
        {
            var tenant_id = _contextAccessor.HttpContext.Request.Headers["Tenant-Id"].ToString();
            if (tenant_id == null)
            {
                return new UnauthorizedResult();
            }

            var result = await userService.GetToken(user,tenant_id);
            if (result == null)
            {
                return new UnauthorizedResult();
            }

            // 设置响应报文头
            _contextAccessor.HttpContext.Response.Headers["access-token"] = result[0];
            _contextAccessor.HttpContext.Response.Headers["x-access-token"] = result[1];
            return new OkResult();
        }

        [HttpGet(Name = "Logout")]
        public bool Logout()
        {
            _contextAccessor.HttpContext.Response.Headers["access-token"] = "";
            _contextAccessor.HttpContext.Response.Headers["x-access-token"] = "";
            return true;
        }
    }
}
