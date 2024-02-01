using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Core.SignalR;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.RedisMQ.Entity;

namespace 通用订票.RedisMQ
{
    public class OrderCreateSubscribe : IRedisSubscribe
    {
        private readonly ICacheOperation _cache;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ILogger<OrderCreateSubscribe> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISignalRUserService userapp;
        private readonly IQueuePushInfo _queue;

        public OrderCreateSubscribe(ILogger<OrderCreateSubscribe> _logger, IServiceProvider _serviceProvider,
            ICacheOperation _cache, ISignalRUserService userapp, IHubContext<ChatHub> _hubContext,IQueuePushInfo _queue)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
            this.userapp = userapp;
            this._hubContext = _hubContext;
            this._queue = _queue;
        }

        [Subscribe("CreateOrder")]
        public async Task CreateOrder(string json)
        {
            _logger.LogInformation("订单创建");
            var data = JsonConvert.DeserializeObject<OrderCreate>(json);
            if (data == null)
            {
                await Task.CompletedTask;
                return;
            }

            DateTime now = DateTime.Now;
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            var client = userapp.isOnline(data.userid.ToString());
            using (var scope = _serviceProvider.CreateScope())
            {
                DbContext dbContext = Db.GetDbContext(scope.ServiceProvider);
                #region 获取services
                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IAppointmentService>>();
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IMyOrderServices>>();

                var s_service = factory.GetStockService(_stockProvider);
                var o_service = factory.GetOrderService(_orderProvider);
                
                s_service = ServiceFactory.GetNamedSaasService<IAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
                o_service = ServiceFactory.GetNamedSaasService<IMyOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
                #endregion

                o_service.SetUserContext(data.userid);
                通用订票.Core.Entity.Order order = null;
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var stockret = s_service.SaleStock(data.appid, data.ids.Count).Result;

                        if (stockret != null)
                        {
                            order = o_service.CreateOrder(stockret.id,stockret.stockName,data.price * data.ids.Count).Result;
                        }
                        else
                        {
                            await sendMessage(client, JsonConvert.SerializeObject(new { code = 0, message = "库存不足" }));
                            await ValueTask.CompletedTask;
                            throw new Exception("库存不足");
                        }
                        await transaction.CommitAsync();

                        var startTime = now.AddDays(stockret.day).Date.Add(stockret.startTime.TimeOfDay);
                        var endTime = now.AddDays(stockret.day).Date.Add(stockret.endTime.TimeOfDay);

                        var CreateTickets = new TicketCreateQueueEntity(new TicketCreate()
                        {
                            startTime = startTime,
                            endTime = endTime,
                            order = order,
                            tenantId = data.tenantId,
                            uid = data.ids,
                            userid = data.userid
                        });

                        await _queue.PushMessage(CreateTickets);

                        var CloseOrder = new OrderCloseQueueEntity(
                            new OrderClose()
                            {       
                                trade_no = order.trade_no, 
                                app = stockret, 
                                tickets = null,
                                delay = 10, 
                                tenantId = data.tenantId,
                                realTenantId = data.realTenantId }
                            );

                        await _queue.PushMessageDelay(CloseOrder, DateTime.Now.AddSeconds(60));

                        await sendMessage(client, JsonConvert.SerializeObject(new
                        {
                            code = 1,
                            message = "订单创建成功",
                            detail = order
                        }));
                    }
                    catch (Exception ex)
                    {
                        if (order != null)
                        {
                            await o_service.AfterOrderToke(order.trade_no);
                        }
                        await s_service.DelStockFromCache(data.appid);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception e) { throw e; }

                    }
                    finally
                    {
                        await _cache.Decrby("QueueIn_" + data.appid, data.ids.Count);
                    }
                }
            }
            await Task.CompletedTask;

        }
        private async Task sendMessage(RealOnlineClient client, object message)
        {
            if (client != null && client.ConnId != null)
            {
                await _hubContext.Clients.Client(client.ConnId).SendAsync("ReceiveMessage",message);
            }
        }
    }
}