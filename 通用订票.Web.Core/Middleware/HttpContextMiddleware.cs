using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Web.Core
{

    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// 构造 Http 请求中间件
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="cacheService"></param>
        public HttpContextMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<HttpContextMiddleware>();
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

            var response = context.Response;

            if (request.Path.Value.StartsWith("/shagou1"))
            {
                request.Path = new PathString(request.Path.Value.Replace("/shagou1", ""));
                request.Host = new HostString("192.168.51.109", 5003);
            }
            else if (request.Path.Value.StartsWith("/shagou2"))
            {
                request.Path = new PathString(request.Path.Value.Replace("/shagou2", ""));
                request.Host = new HostString("192.168.51.109", 5004);
            }
            else if (request.Path.Value.StartsWith("/anfeng"))
            {
                request.Path = new PathString(request.Path.Value.Replace("/anfeng", ""));
                request.Host = new HostString("192.168.51.109", 5005);
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
