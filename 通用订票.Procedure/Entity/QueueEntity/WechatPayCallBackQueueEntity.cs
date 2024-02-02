using Core.Queue;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Procedure.Entity.QueueEntity
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
