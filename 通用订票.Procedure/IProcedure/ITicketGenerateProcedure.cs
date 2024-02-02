using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.IService;

namespace 通用订票.Procedure.IProcedure
{
    public interface ITicketGenerateProcedure : IPreload
    {
        Task<ICollection<Ticket>> StartProcess(TicketCreate param);
        Task AfterProcess();
    }
}
