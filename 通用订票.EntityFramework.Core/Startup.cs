using Core.EntityFrameWork;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;

namespace 通用订票.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                var dbType = App.Configuration["ConnectionStrings:DbType"];
                if (dbType == "SqlServer")
                {
                    options.AddDb<MyDefaultDbContext>();
                    options.AddDbPool<MultiTenantDbContext, MultiTenantDbContextLocator>();
                }
                else if(dbType == "MySql")
                {
                    options.AddDb<MyDefaultDbContext_MYSQL>();
                    options.AddDbPool<MultiTenantDbContext_MYSQL, MultiTenantDbContextLocator>();
                }
                
               
            }, "通用订票.Database.Migrations");
            
        }
    }
}