using Core.Auth;
using Core.Auth.Handler;
using Core.Cache;
using Core.Config;
using Core.HttpTenant.HttpTenantContext;
using Core.HttpTenant.Service;
using Core.MiddelWares;
using Core.Queue.IQueue;
using Core.SignalR;
using Core.User.Service;
using Core.Utill.UniqueCode;
using Essensoft.Paylink.WeChatPay;
using Furion;
using Furion.Core;
using Furion.DatabaseAccessor;
using Furion.Schedule;
using InitQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProtoBuf.Meta;
using Quick.RabbitMQPlus;
using Savorboard.CAP.InMemoryMessageQueue;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.EntityFramework.Core;
using 通用订票.EventBus.Monitor;
using 通用订票.JobTask;
using 通用订票.RedisMQ;

namespace 通用订票.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsoleFormatter();
            Array.ForEach(new[] { LogLevel.Error}, logLevel =>
            {
                services.AddFileLogging("log/application-{1}-{0:yyyy}-{0:MM}-{0:dd}.log", options =>
                {
                    options.FileNameRule = fileName => string.Format(fileName, DateTime.UtcNow, logLevel.ToString());
                    options.WriteFilter = logMsg => logMsg.LogLevel == logLevel;
                });
            });

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
            services.AddWeChatPay();
            services.Configure<WeChatPayOptions>(App.Configuration.GetSection("WeChatPay"));
            services.AddSingleton<ICacheOperation, RedisOperationRepository>();
            services.AddSingleton<ISignalRUserService, JwtCacheUserService>();

            Configration.ConfigInit();

            if (Configration.UseTenant == true)
            {
                services.AddTenantService(Configration.tenantConfigType);
            }

            services.AddSingleton<IUniqueCodeGenerater<long>,RedisUniqueCodeGenerator>();
            services.AddSingleton<ITradeNoGenerater<long>, TradeNoGenerater>();
            services.AddSingleton<IIdGenerater<long>, IdGenerater>();

            services.AddTransient<IWechatMerchantConfigService,WechatTenantMerchantConfigService>();
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                //获取连接字符串
                string redisConfiguration = Configration.redisConnectionString;
                var configuration = ConfigurationOptions.Parse(redisConfiguration, true);
                configuration.ResolveDns = true;
                configuration.DefaultDatabase = 0;
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddInitQ(m =>
            {
                //时间间隔
                m.SuspendTime = 1000;
                //redis服务器地址
                m.ConnectionString = Configration.redisConnectionString;
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
            services.AddSingleton<IQueuePushInfo, InitQRedisPushMessage>();
            services.AddEventBus(builder => {
                builder.AddMonitor<EventHandlerMonitor>();
            });

            //services.AddCap(options =>
            //{
            //    options.UseMySql(App.Configuration["ConnectionStrings:SqlConnection"]);
            //    options.UseEntityFramework<MyDefaultDbContext_MYSQL>();
            //    options.UseDashboard();

            //    options.UseInMemoryMessageQueue();
            //}).AddSubscriberAssembly(App.Assemblies.ToArray());

            //services.AddRabbitMQPlus();
            //services.AddHostedService<Worker>();

            services.AddResponseCaching();
            services.AddCorsAccessor();

            services.AddSignalR().AddStackExchangeRedis(Configration.redisConnectionString, options => {
                options.Configuration.ChannelPrefix = Configration.CachePrefix;
            });
           
            services.AddSchedule(options =>
            {
                options.BuildSqlType = SqlTypes.SqlServer;
                options.ClusterId = Configration.ClusterId;
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

            if (App.Configuration["ServerConfig:SubSite:IsSubSite"] == "true")
            {
                app.UseMiddleware<SubSiteMiddleWare>();
            }
            app.UseMiddleware<HttpContextMiddleware>();
            //app.UseMiddleware<WebRouteMiddleware>();

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
                //endpoints.MapHub<ChatHub>("/hubs/chathub");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
