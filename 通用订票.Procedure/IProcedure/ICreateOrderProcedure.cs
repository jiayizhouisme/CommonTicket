using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IService;

namespace 通用订票.Procedure.IProcedure
{
    public interface ICreateOrderProcedure : IPreload
    {
        Task<Core.Entity.Order> StartProcess(OrderCreate param);
        Task AfterProcess();
    }
}
