using Core.Auth;
using Core.EntityFrameWork;
using Furion;
using Microsoft.EntityFrameworkCore;

namespace 通用订票.EntityFramework.Core
{
    public class MyDefaultDbContext_MYSQL : DefaultDbContext<MyDefaultDbContext_MYSQL>
    {
        public MyDefaultDbContext_MYSQL(DbContextOptions<MyDefaultDbContext_MYSQL> options, IHttpContextUser user) : base(options, user)
        {
            this.SetConnectString(App.Configuration["ConnectionStrings:SqlConnection"]);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = GetDatabaseConnectionString();
            ServerVersion sv = ServerVersion.AutoDetect(connStr);
            optionsBuilder.UseMySql(connStr, sv, options =>
            {
                options.MigrationsAssembly(App.Configuration["ConnectionStrings:Migrations"]);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
