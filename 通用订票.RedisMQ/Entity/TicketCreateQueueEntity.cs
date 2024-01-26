using Core.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Models;

namespace 通用订票.RedisMQ.Entity
{
    public class TicketCreateQueueEntity : IQueueEntity
    {
        private TicketCreate entity { get; set; }
        public TicketCreateQueueEntity(TicketCreate entity)
        {
            this.entity = entity;
        }

        public string name { get => "CreateTickets"; }
        public object body { get => entity; }
    }
}
