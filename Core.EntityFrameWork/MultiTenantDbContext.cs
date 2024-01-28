﻿using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFrameWork
{
    public class MultiTenantDbContext : AppDbContext<MultiTenantDbContext, MultiTenantDbContextLocator>
    {
        public MultiTenantDbContext(DbContextOptions<MultiTenantDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = App.Configuration["ConnectionStrings:SqlConnection"];
            if (App.Configuration["ConnectionStrings:DbType"] == "SqlServer")
            {
                optionsBuilder.UseSqlServer(connStr, options =>
                {
                    options.MigrationsAssembly("通用订票.Database.Migrations");
                });
            }
            else if(App.Configuration["ConnectionStrings:DbType"] == "MySql")
            {
                ServerVersion sv = ServerVersion.AutoDetect(connStr);
                optionsBuilder.UseMySql(connStr,sv, options =>
                {
                    options.MigrationsAssembly("通用订票.Database.Migrations");
                });
            }
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
