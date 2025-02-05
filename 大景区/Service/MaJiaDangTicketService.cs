﻿using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;

namespace 通用订票.大景区.Service
{
    [Injection(Order = 0)]
    public class MaJiaDangTicketService : DefaultTicketService, ITransient
    {
        public MaJiaDangTicketService(IRepository<Core.Entity.Ticket, MasterDbContextLocator> _dal,
            ICacheOperation _cache,IMultiTicketService multiTicketService) : base(_dal, _cache,multiTicketService)
        {
        }
    }
}