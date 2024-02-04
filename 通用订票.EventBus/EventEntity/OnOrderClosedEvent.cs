using Furion.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.EventBus.Entity;

namespace 通用订票.EventBus.EventEntity
{
    public class OnOrderClosedEvent : IEventSource
    {
<<<<<<<< HEAD:通用订票.EventBus/EventEntity/OnOrderClosedEvent.cs
        public OnOrderClosedEvent(OnOrderClosed oc)
        {
            this.Payload = oc;
            EventId = "OnOrderClosed";
========

        public OrderCreateFailEvent(OnOrderCreateFail oc)
        {
            this.Payload = oc;
            EventId = "OnOrderCreateFail";
>>>>>>>> 483619beeb1568f0e259e1799ee8f47cc5b9e54b:通用订票.EventBus/EventEntity/OrderCreateFailEvent.cs
        }

        /// <summary>
        /// 事件 Id
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// 事件承载（携带）数据
        /// </summary>
        public object Payload { get; set; }

        /// <summary>
        /// 事件创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 取消任务 Token
        /// </summary>
        /// <remarks>用于取消本次消息处理</remarks>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public CancellationToken CancellationToken { get; set; }

        public bool IsConsumOnce => false;
    
    }
}
