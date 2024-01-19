using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 订票系统.Rules.IService
{
    public interface IRuleService<T>
    {
        public bool Vaild(T entity);
    }
}
