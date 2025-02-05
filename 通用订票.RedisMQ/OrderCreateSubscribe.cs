﻿using Consul;
using Core.Auth;
using Core.Cache;
using Core.Queue;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Core.SignalR;
using DotNetCore.CAP.Dashboard;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;
using StackExchange.Redis;
using System;
using System.Net.Sockets;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
using 通用订票Order.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.RedisMQ
{
    public class OrderCreateSubscribe : IRedisSubscribe
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IServiceProvider _serviceProvider;
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ICacheOperation _cache;
        private readonly IQueuePushInfo _queue;
        private readonly ILogger<OrderCreateSubscribe> _logger;
        public OrderCreateSubscribe(
            IEventPublisher _eventPublisher,
            IJsonSerializerProvider jsonSerializerProvider,
            IServiceProvider _serviceProvider,
            ICacheOperation _cache,
            ILogger<OrderCreateSubscribe> logger,
            IQueuePushInfo _queue)
        {
            this._eventPublisher = _eventPublisher;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this._serviceProvider = _serviceProvider;
            this._cache = _cache;
            _logger = logger;
            this._queue = _queue;
        }

        [Subscribe("CreateOrder")]
        public async Task CreateOrder(string json)
        {
            IDefaultAppointmentService s_service;
            OrderCreate data = jsonSerializerProvider.Deserialize<OrderCreate>(json);
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope()) 
            {

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>
                    (scope.ServiceProvider, s_service, data.tenantId);
                var locker = _cache.Lock("OrderCloseLock:" + data.appid, data.appid).Result;
                Appointment app = null;
                try
                {
                    app = s_service.checkStock(data.appid).Result;
                    app.sale += data.ids.Count;
                    s_service.UpdateNow(app).Wait();
                    await s_service.DelStockFromCache(app.id);
                }
                catch
                {
                    await s_service.SaleStock(data.appid,-data.ids.Count);
                }
                finally
                {
                    await _cache.ReleaseLock("OrderCloseLock:" + data.appid, data.appid);
                }

                if (data.order.amount == 0)
                {
                    var startTime = data.order.createTime.Value.AddDays(app.day).Date.Add(app.startTime.TimeOfDay);
                    var endTime = data.order.createTime.Value.AddDays(app.day).Date.Add(app.endTime.TimeOfDay);

                    var e_service = ServiceFactory.GetSaasService<IExhibitionService,Exhibition>(scope.ServiceProvider,data.tenantId);
                    var exhibition = await e_service.GetExhibitionByID(app.objectId);
                    if (exhibition.isMultiPart == true)
                    {
                        await _queue.PushMessage(new TicketCreateQueueEntity(new TicketCreate()
                        {
                            startTime = startTime,
                            endTime = endTime,
                            exhibitions = exhibition.exhibitions.Split(' '),
                            order = data.order,
                            status = Base.Entity.TicketStatus.未使用,
                            tenantId = data.tenantId,
                            uid = data.order.GetExtraInfo().ids,
                            userid = data.order.userId
                        }));
                    }
                    else
                    {
                        await _queue.PushMessage(new TicketCreateQueueEntity(new TicketCreate()
                        {
                            startTime = startTime,
                            endTime = endTime,
                            exhibitions = null,
                            order = data.order,
                            //realTenantId = httpContextUser.RealTenantId,
                            status = Base.Entity.TicketStatus.未使用,
                            tenantId = data.tenantId,
                            uid = data.order.GetExtraInfo().ids,
                            userid = data.order.userId
                        }));
                    }
                }
                else
                {
                    var CreateOrder = new OrderCloseQueueEntity(new OrderClose()
                    {
                        trade_no = data.order.trade_no,
                        appid = data.appid,
                        userId = data.userid,
                        delay = 30,
                        tenantId = data.tenantId,
                        count = data.ids.Count,
                        realTenantId = data.tenantId
                    });
                    await _queue.PushMessageDelay(CreateOrder, DateTime.Now.AddSeconds(60));
                }
            }
           
            await Task.CompletedTask;
        }

        private async Task PublishOrderCreateFail(Appointment stockret,Core.Entity.Order order,int count,string tenantId, long userId)
        {
            var entity = new OnOrderCreateFailed() { app = stockret, order = order, count = count, tenantId = tenantId, userId = userId };
            await _eventPublisher.PublishAsync(new OnOrderCreateFailedEvent(entity));
        }

    }
}