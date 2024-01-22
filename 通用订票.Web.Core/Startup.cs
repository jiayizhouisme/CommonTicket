using Essensoft.Paylink.WeChatPay;
using Furion;
using Furion.Schedule;
using Furion.VirtualFileServer;
using InitQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using 订票系统.Rules.IService;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.ServiceBases.Service;
using Core.Cache;
using 通用订票.Core.Entity;
using Core.SignalR;
using 通用订票.RedisMQ;
using 通用订票.JobTask;
using Core.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using Core.Auth.Handler;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Factory.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using System.Net.Http;

namespace 通用订票.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsoleFormatter();
            services.AddJwt<JwtHandler>(jwtBearerConfigure : options => {
                options.Events = new JwtBearerEvents
                {
                    // 添加额外 Token 读取处理
                    // 可以在这里实现任何方式的读取 Token，然后设置给 context.Token 即可
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Query.ContainsKey("access_token"))
                        {
                            var token = context.Request.Query["access_token"];
                            // 设置 Token
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    }
                };

            });
            services.Add(ServiceDescriptor.Singleton<MyBeetleX, MyBeetleX>());
            services.Add(ServiceDescriptor.Singleton<RedisOperationRepository, RedisOperationRepository>());
            services.Add(ServiceDescriptor.Singleton<ISignalRUserService, JwtCacheUserService>());
            services.AddWeChatPay();
            services.Configure<WeChatPayOptions>(App.Configuration.GetSection("WeChatPay"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHttpContextUser, JwtUserContext>();
            
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                //获取连接字符串
                string redisConfiguration = App.Configuration["RedisConfig:ConnectionString"];
                var configuration = ConfigurationOptions.Parse(redisConfiguration, true);
                configuration.ResolveDns = true;
                configuration.ChannelPrefix = App.Configuration["ServerConfig:CachePrefix"];
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddInitQ(m =>
            {
                //时间间隔
                m.SuspendTime = 1000;
                //redis服务器地址
                m.ConnectionString = App.Configuration["RedisConfig:ConnectionString"];
                //对应的订阅者类，需要new一个实例对象，当然你也可以传参，比如日志对象
                m.ListSubscribe = new List<Type>() {
                    typeof(OrderCloseSubscribe),
                    typeof(OrderCreateSubscribe),
                    typeof(WeChatPayNoticeSubscribe),
                    typeof(TicketGenerateSubscribe)
                };
                //显示日志
                m.ShowLog = false;
            });

            services.AddResponseCaching();
            services.AddCorsAccessor();

            services.AddSignalR().AddStackExchangeRedis(App.Configuration["RedisConfig:ConnectionString"], options => {
                options.Configuration.ChannelPrefix = App.Configuration["ServerConfig:CachePrefix"];
            });

            services.AddSchedule(options =>
            {
                options.BuildSqlType = SqlTypes.SqlServer;
                options.ClusterId = App.Configuration["ServerConfig:ClusterId"];
                options.AddClusterServer<JobClusterServer>();
                //options.AddPersistence<DbJobPersistence>();
            });


            services.AddControllersWithViews()
                        .AddInjectWithUnifyResult().AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                            options.JsonSerializerOptions.PropertyNamingPolicy = null;
                            options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                        });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            StaticFileOptions options = new StaticFileOptions { 
                ContentTypeProvider = new FileExtensionContentTypeProvider()
            
            };

            ((FileExtensionContentTypeProvider)options.ContentTypeProvider).
                Mappings.Add(new KeyValuePair<string, string>(".gltf", "model/gltf-binary"));
            ((FileExtensionContentTypeProvider)options.ContentTypeProvider).
                Mappings.Add(new KeyValuePair<string, string>(".lrc", "application/octet-stream"));
            app.UseStaticFiles(options);

            // 还可以配置生产环境关闭
            app.UseScheduleUI(options =>
            {
                options.RequestPath = "/custom-job";
                options.DisableOnProduction = false;
            });

            app.UseResponseCaching();
            app.UseRouting();

            app.UseCorsAccessor();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseInject();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hubs/chathub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}