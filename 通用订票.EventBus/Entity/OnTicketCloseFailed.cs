﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.EventBus.Entity
{
    public class OnTicketCloseFailed : BaseEntity
    {
        public Core.Entity.Order order { get; set; }
    }
}
