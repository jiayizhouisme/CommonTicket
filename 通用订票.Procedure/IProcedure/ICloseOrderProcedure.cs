using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IService;

namespace 通用订票.Procedure.IProcedure
{
    public interface ICloseOrderProcedure : IPreload
    {
        Task<Core.Entity.Order> StartProcess(OrderClose param);
        Task AfterProcess();
    }
}
