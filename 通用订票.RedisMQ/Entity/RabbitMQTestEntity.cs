using Core.Queue;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quick.RabbitMQPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;

namespace 通用订票.RedisMQ.Entity
{
    [QuickRabbitMQPlusReceive("CreateOrder")]
    public class RabbitMQTestEntity1 : IQueueEntity
    {
        public object entity;

        public string name => "CreateOrder";

        [JsonIgnore]
        public object body { get { return this.entity; } }
    }

    [QuickRabbitMQPlusReceive("CloseOrder")]
    public class RabbitMQTestEntity2 : IQueueEntity
    {
        public object entity;
        public string name { get => "CloseOrder"; }
        [JsonIgnore]
        public object body { get { return this.entity; } }
    }

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IQuickRabbitMQPlus _quickRabbitMqPlus;

        public Worker(ILogger<Worker> logger, IQuickRabbitMQPlus quickRabbitMqPlus)
        {
            _logger = logger;
            _quickRabbitMqPlus = quickRabbitMqPlus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //接收队列1的消息
                var retRec1 = await _quickRabbitMqPlus.Receive<RabbitMQTestEntity1>(async (data, msg) =>
                {
                    _logger.LogInformation("接收到消息1");
                    await Task.Delay(2000);
                    

                    //返回true代表业务逻辑处理成功，会告知MQ这条消息已经接收成功，会从MQ队列中删除
                    //返回false代表业务逻辑处理失败，会告知MQ这条消息没有处理成功，则MQ会继续推送这条消息
                    return true;
                }, async (errMsg, msg) =>
                {
                    await Task.Delay(3000);
                }, 1);
                if (!retRec1.Item1)
                {
                }

                //接收队列2的消息
                var retRec2 = await _quickRabbitMqPlus.Receive<RabbitMQTestEntity2>(async (data, msg) =>
                {
                    await Task.Delay(2500);


                    //返回true代表业务逻辑处理成功，会告知MQ这条消息已经接收成功，会从MQ队列中删除
                    //返回false代表业务逻辑处理失败，会告知MQ这条消息没有处理成功，则MQ会继续推送这条消息
                    return false;
                }, async (errMsg, msg) =>
                {
                    await Task.Delay(3000);
                }, 10);
                if (!retRec2.Item1)
                {
                }
                await Task.Delay(1000);
            }
        }
    }
}
