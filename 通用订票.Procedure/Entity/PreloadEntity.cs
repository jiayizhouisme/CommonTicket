using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Procedure.Entity
{
    public class PreloadEntity
    {
        public IServiceScope Scope { get; set; }
        public Guid Userid { get; set; }
        public string TenantId { get; set; }
    }
}
