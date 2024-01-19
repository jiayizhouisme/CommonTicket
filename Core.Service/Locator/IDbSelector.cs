using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;

namespace Core.Services.Locator
{
    public interface IDbSelector<T> where T : class, IPrivateEntity, new()
    {
        public IBaseService<T> SetDbConnectString(string connStr);
    }
}
