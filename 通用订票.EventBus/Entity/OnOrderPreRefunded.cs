using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using 通用订票.Procedure.Entity;

namespace 通用订票.EventBus.Entity
{
    public class OnOrderPreRefunded : BaseEntity
    {
        public Core.Entity.Order order;
        public WechatBillRefund billRefund;
        public WechatBill bill;
    }
}
