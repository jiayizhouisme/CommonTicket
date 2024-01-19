using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.SeedData
{
    public class TenantSeedData : IEntitySeedData<Tenant, MultiTenantDbContextLocator>
    {
        public IEnumerable<Tenant> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new List<Tenant>
            {
                new Tenant
                {
                    TenantId = Guid.Parse("383AFB88-F519-FFF8-B364-6D563BF3687F"),
                    Name = "默认租户",
                    Host = "localhost:44313",
                    CreatedTime = DateTime.Parse("2020-10-06 20:19:07"),
                    ConnectionString = App.Configuration["ConnectionStrings:SqlConnection"]
                },
                new Tenant
                {
                    TenantId = Guid.Parse("C5798CB6-16D6-0F42-EB56-59C695353BC0"),
                    Name = "其他租户",
                    Host = "localhost:5000",
                    CreatedTime = DateTime.Parse("2020-10-06 20:20:32"),
                    ConnectionString = App.Configuration["ConnectionStrings:SqlConnection2"]
                }
            };
        }
    }
}
