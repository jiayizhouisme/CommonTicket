using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Ticket.Entity;

namespace 订票系统.Rules.IService
{
    public interface IBaseTicketRuleService<T> : IRuleService<T> where T : TicketAbstract
    {
    }
}
