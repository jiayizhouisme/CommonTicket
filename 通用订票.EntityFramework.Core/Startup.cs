using Core.Config;
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
                var dbType = Configration.DbType;
                if (dbType == "SqlServer")
                {
                    options.AddDb<MasterDbContext_SQL>();
                    options.AddDbPool<MultiTenantDbContext_SQL, MultiTenantDbContextLocator>();
                }
                else if(dbType == "MySql")
                {
                    options.AddDb<MasterDbContext_MYSQL>();
                    options.AddDbPool<MultiTenantDbContext_MYSQL, MultiTenantDbContextLocator>();
                }
                
               
            }, "通用订票.Database.Migrations");
            
        }
    }
}