using Core.Auth;
using Core.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.EntityFramework.Core
{
    public class MyDefaultDbContext : DefaultDbContext<MyDefaultDbContext>
    {
        public MyDefaultDbContext(DbContextOptions<MyDefaultDbContext> options, IHttpContextUser user) : base(options, user)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = GetDatabaseConnectionString();
            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.MigrationsAssembly("通用订票.Database.Migrations");
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
