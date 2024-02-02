using Core.Queue;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;

namespace 通用订票.Procedure.Entity.QueueEntity
{
    public class OrderCreateQueueEntity : IQueueEntity
    {
        private OrderCreate entity { get; set; }
        public OrderCreateQueueEntity(OrderCreate entity)
        {
            this.entity = entity;
        }

        public string name { get => "CreateOrder"; }
        public object body { get => entity; }
    }
}
