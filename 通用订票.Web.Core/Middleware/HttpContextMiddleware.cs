using Core.User.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;

namespace 通用订票.Web.Core
{

    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly TenantService ts;

        /// <summary>
        /// 构造 Http 请求中间件
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="cacheService"></param>
        public HttpContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, TenantService ts)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<HttpContextMiddleware>();
            this.ts = ts;
        }

        /// <summary>
        /// 1：将Post方法中Body中的数据进行AES解密
        /// 2：将返回数据进行AES加密
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            var request = context.Request;

            var first = request.Path.Value.Split('/')[1];

            var tenant = await ts.GetTenant(first);
            if (tenant != null)
            {
                request.Headers.Append("Origin_Host", request.Host.ToString());
                request.Path = new PathString(request.Path.Value.Replace("/" + tenant.Name, ""));
                request.Host = new HostString(tenant.Host);
                request.Headers.Append("Tenant_Name", tenant.Name);
            }

            await _next.Invoke(context);
            // 响应完成时存入缓存
            context.Response.OnCompleted(() =>
            {
                return Task.CompletedTask;
            });
        }
    }
}
