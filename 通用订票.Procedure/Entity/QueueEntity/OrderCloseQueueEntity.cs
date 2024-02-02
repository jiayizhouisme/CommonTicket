using Core.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;

namespace 通用订票.Procedure.Entity.QueueEntity
{
    public class OrderCloseQueueEntity : IQueueEntity
    {
        private OrderClose entity { get; set; }
        public OrderCloseQueueEntity(OrderClose entity)
        {
            this.entity = entity;
        }

        public string name { get => "CloseOrder"; }
        public object body { get => entity; }
    }
}
