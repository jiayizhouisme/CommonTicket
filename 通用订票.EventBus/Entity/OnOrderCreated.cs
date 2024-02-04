using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus.Entity
{
    public class OnOrderCreated : BaseEntity
    {
        public Guid id;
        public Appointment app;
        public Core.Entity.Order order;
        public ICollection<int> ids;
    }
}
