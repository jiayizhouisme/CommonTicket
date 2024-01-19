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
                options.AddDb<MyDefaultDbContext>();
                options.AddDbPool<MultiTenantDbContext, MultiTenantDbContextLocator>();
            }, "通用订票.Database.Migrations");
            
        }
    }
}