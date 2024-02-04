using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace 通用订票.EventBus.Entity
{
<<<<<<<< HEAD:通用订票.EventBus/Entity/OnOrderCreateFailed.cs
    public class OnOrderCreateFailed : BaseEntity
========
    public class OnOrderCreateFail : BaseEntity
>>>>>>>> 483619beeb1568f0e259e1799ee8f47cc5b9e54b:通用订票.EventBus/Entity/OnOrderCreateFail.cs
    {
        public Core.Entity.Order order { get; set; }
        public Appointment app { get; set; }
        public int count { get; set; }
    }
}
