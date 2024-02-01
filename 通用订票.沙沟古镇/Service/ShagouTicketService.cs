﻿using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;

namespace 通用订票.沙沟古镇.Service
{
    [Injection(Order = 0)]
    public class ShagouTicketService : DefaultTicketService, ITransient
    {
        public ShagouTicketService(IRepository<Core.Entity.Ticket> _dal, ICacheOperation _cache) : base(_dal, _cache)
        {
        }
    }
}