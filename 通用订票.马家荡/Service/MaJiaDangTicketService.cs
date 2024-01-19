﻿using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;

namespace 通用订票.马家荡.Service
{
    [Injection(Order = 0)]
    public class MaJiaDangTicketService : MyTicketService, ITransient
    {
        public MaJiaDangTicketService(IRepository<Core.Entity.Ticket> _dal, MyBeetleX _cache) : base(_dal, _cache)
        {
        }
    }
}