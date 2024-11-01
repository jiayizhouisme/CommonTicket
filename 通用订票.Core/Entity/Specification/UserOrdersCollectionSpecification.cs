using Core.Services.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 通用订票Order.Entity;

namespace 通用订票.Core.Entity.Specification
{
    /// <summary>
    /// 用户在指定appid下的有效订单(未付款的或者已付款的)
    /// </summary>
    
    public class UserOrdersCollectionSpecification : Specification<Order>
    {
        private long userId;
        private string appid;
        public UserOrdersCollectionSpecification(long userId, string appid)
        {
            this.userId = userId;
            this.appid = appid;
        }
        public override Expression<Func<Order, bool>> ToExpression()
        {
            var now = DateTime.Now;
            return m => m.userId == userId && 
            m.objectId == appid && 
            (m.status == OrderStatus.未付款 || m.status == OrderStatus.已付款) && 
            now.CompareTo(m.expireDate) <= 0;
        }
    }
}
