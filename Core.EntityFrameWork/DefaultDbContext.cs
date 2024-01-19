﻿using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Auth;
using Furion.DependencyInjection;
using Furion.JsonSerialization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Profiling.Internal;

namespace Core.EntityFrameWork
{
    public abstract class DefaultDbContext<T> : AppDbContext<T>, IMultiTenantOnDatabase where T : DbContext
    {
        private readonly IHttpContextUser user;

        public DefaultDbContext(DbContextOptions<T> options, IHttpContextUser user) : base(options)
        {
            this.user = user;
        }

        public string GetDatabaseConnectionString()
        {
            
            if (user.TenantId != null)
            {
                try
                {
                    var t = base.Tenant;
                    return t.ConnectionString;
                }
                catch 
                {
                    throw new System.Exception(user.TenantId);
                }
            }
            else
            {
                return App.Configuration["ConnectionStrings:SqlConnection"];
            }
        }

    }
}