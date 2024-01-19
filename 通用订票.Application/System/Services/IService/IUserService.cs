using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using Core.Services;
using Core.User.Service;

namespace 通用订票.Application.System.Services.IService
{
    public interface IUserService : IUserLoginService<User>,IBaseService<User>
    {
        public Task<string[]> GetToken(User user, string extra_info);
    }
}
