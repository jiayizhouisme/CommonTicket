﻿using Furion;
using Furion.DatabaseAccessor;
using InitQ.Abstractions;
using InitQ.Attributes;
using InitQ.Cache;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using System;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.ServiceBases.IService;
using Core.Services.ServiceFactory;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.BaseEntity;
using 通用订票.Core.Entity;
using Core.SignalR;
using Core.Auth;
using 通用订票Order.Entity;
using Furion.DependencyInjection;
using ProtoBuf.Serializers;
using 通用订票.Application.System.IService.Factory;
using 通用订票.沙沟古镇.Factory;
using 通用订票.沙沟古镇.Service;
using 通用订票.Application.System.Factory.Service;

namespace 通用订票.RedisMQ
{
    public class OrderCreateSubscribe : IRedisSubscribe
    {
        private readonly MyBeetleX _cache;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ILogger<OrderCreateSubscribe> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICacheService _initQRedis;
        private readonly ISignalRUserService userapp;

        public OrderCreateSubscribe(ILogger<OrderCreateSubscribe> _logger, IServiceProvider _serviceProvider, ICacheService _initQRedis,
            MyBeetleX _cache, ISignalRUserService userapp, IHubContext<ChatHub> _hubContext)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
            this._initQRedis = _initQRedis;
            this.userapp = userapp;
            this._hubContext = _hubContext;
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
                        await _initQRedis.ListLeftPushAsync("CreateTickets",
                            JsonConvert.SerializeObject(new TicketCreate() {
                                    startTime = startTime,
                                    endTime = endTime,
                                    order = order,
                                    tenantId = data.tenantId,
                                    uid = data.ids,
                                    userid = data.userid
                                }
                                ));

                        await _initQRedis.SortedSetAddAsync("CloseOrder",
                            JsonConvert.SerializeObject(
                                new OrderClose() { orderid = order.id, app = stockret, tickets = null, delay = 10, tenantId = data.tenantId ,realTenantId = data.realTenantId}
                                ),
                            DateTime.Now.AddSeconds(60));

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
                            await o_service.AfterOrderToke(order.id);
                        }
                        await s_service.DelStockFromCache(data.appid);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception e) { throw e; }

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
                //await _hubContext.Clients.All.SendAsync("ReceiveMessage",message);
            }
        }
    }
}