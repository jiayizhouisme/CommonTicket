﻿using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Core.SignalR;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.RedisMQ
{
    public class OrderCreateSubscribe : IRedisSubscribe
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly IServiceProvider _serviceProvider;
        private readonly IJsonSerializerProvider jsonSerializerProvider;

        public OrderCreateSubscribe(
            IHubContext<ChatHub> _hubContext,
            IEventPublisher _eventPublisher,
            IJsonSerializerProvider jsonSerializerProvider,
            IServiceProvider _serviceProvider)
        {
            this._hubContext = _hubContext;
            this._eventPublisher = _eventPublisher;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this._serviceProvider = _serviceProvider;
        }

        [Subscribe("CreateOrder")]
        public async Task CreateOrder(string json)
        {
            IDefaultAppointmentService s_service;
            IDefaultOrderServices o_service;
            OrderCreate data = jsonSerializerProvider.Deserialize<OrderCreate>(json);
            if (data == null)
            {
                return;
            }
            Core.Entity.Order order = null;
            Appointment stockret = null;
            var factory = SaaSServiceFactory.GetServiceFactory(data.tenantId);
            using (var scope = _serviceProvider.CreateScope())
            {
                #region 获取services
                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();

                s_service = factory.GetStockService(_stockProvider);
                o_service = factory.GetOrderService(_orderProvider);

                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, data.tenantId);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenantId);
                #endregion
                o_service.SetUserContext(data.userid);
                try
                {
                    stockret = s_service.SaleStock(data.appid, data.ids.Count).Result;
                    if (stockret != null)
                    {
                        order = o_service.CreateOrder(stockret.id, stockret.stockName, data.price * data.ids.Count).Result;
                        var entity = new OnOrderCreated() { app = stockret,order = order,ids = data.ids,tenantId = data.tenantId,userId = data.userid};
                        await _eventPublisher.PublishAsync(new OnOrderCreatedEvent(entity));
                    }
                    else
                    {
                        await PublishOrderCreateFail(stockret, order, data.ids.Count, data.tenantId, data.userid);
                    }
                }
                catch (Exception e)
                {
                    await PublishOrderCreateFail(stockret,order,data.ids.Count,data.tenantId,data.userid);
                    throw e;
                }
            }
            await Task.CompletedTask;
        }

        private async Task PublishOrderCreateFail(Appointment stockret,Core.Entity.Order order,int count,string tenantId,Guid userId)
        {
            var entity = new OnOrderCreateFailed() { app = stockret, order = order, count = count, tenantId = tenantId, userId = userId };
            await _eventPublisher.PublishAsync(new OrderCreateFailedEvent(entity));
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