using Core.Queue;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;

namespace 通用订票.RedisMQ.Entity
{
    public class WechatPayCallBackQueueEntity : IQueueEntity
    {
        private WeChatPayUnifiedOrderNotify entity { get; set; }
        public WechatPayCallBackQueueEntity(WeChatPayUnifiedOrderNotify entity)
        {
            this.entity = entity;
        }

        public string name { get => "WeChatPayNotice"; }
        public object body { get => entity; }
    }
}
