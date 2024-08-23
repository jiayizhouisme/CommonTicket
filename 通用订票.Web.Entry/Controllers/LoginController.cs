﻿using Core.User.Entity;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
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
        public async Task<IActionResult> Login([FromBody]Login_Web user)
        {
            var tenant_id = _contextAccessor.HttpContext.Request.Headers["Tenant_Name"].ToString();
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

        [HttpGet(Name = "Logout")]
        public bool Logout()
        {
            _contextAccessor.HttpContext.Response.Headers["access-token"] = "";
            _contextAccessor.HttpContext.Response.Headers["x-access-token"] = "";
            return true;
        }
    }
}
