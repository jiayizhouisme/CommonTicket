using Core.Auth;
using Core.EntityFrameWork;
using Furion;
using Microsoft.EntityFrameworkCore;

namespace 通用订票.EntityFramework.Core
{
    public class MyDefaultDbContext : DefaultDbContext<MyDefaultDbContext>
    {
        public MyDefaultDbContext(DbContextOptions<MyDefaultDbContext> options, IHttpContextUser user) : base(options, user)
        {
            this.SetConnectString(App.Configuration["ConnectionStrings:SqlConnection"]);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = GetDatabaseConnectionString();
            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.MigrationsAssembly(App.Configuration["ConnectionStrings:Migrations"]);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
