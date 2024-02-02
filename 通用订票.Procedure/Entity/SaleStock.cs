using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Procedure.Entity
{
    public class SaleStock : IProcedureEntity
    {
        public Guid AppId { get; set; } 
        public int Count { get; set; }
    }
}
