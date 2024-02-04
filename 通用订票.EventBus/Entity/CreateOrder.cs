using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus.Entity
{
    public class CreateOrder : BaseEntity
    {
        public Guid id;
        public string StockName;
        public decimal price;
        public int count;
        public Appointment app;
        public ICollection<int> ids;
    }
}
