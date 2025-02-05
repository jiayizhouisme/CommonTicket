﻿using Core.Cache;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;

namespace 通用订票.小景区.Service
{
    [Injection(Order = 0)]
    public class ShagouStockService : DefaultAppointmentService, ITransient
    {
        public ShagouStockService(IRepository<Appointment> _dal, ICacheOperation _cache) : base(_dal, _cache)
        {
        }
    }
}