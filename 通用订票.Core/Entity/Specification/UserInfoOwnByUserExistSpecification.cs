using Core.Services.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity.Specification
{
    /// <summary>
    /// 当前用户是否拥有指定的游客
    /// </summary>
    public class UserInfoOwnByUserExistSpecification : Specification<UserInfo>
    {
        private long userId;
        private long userInfoId;
        public UserInfoOwnByUserExistSpecification(long userInfoId, long userId)
        {
            this.userInfoId = userInfoId;
            this.userId = userId;
        }

        public override Expression<Func<UserInfo, bool>> ToExpression()
        {
            return m => m.userID == userId && m.id == userInfoId;
        }
    }
}
