using Furion.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.EventBus.Entity;

namespace 通用订票.EventBus.EventEntity
{
    public class OnOrderCreateFailedEvent : IEventSource
    {

        public OnOrderCreateFailedEvent(OnOrderCreateFailed oc)
        {
            this.Payload = oc;
            EventId = "OnOrderCreateFailed";
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
