using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;
using Core.Auth;
using Core.Services;

namespace 通用订票.Application.System.Services.IService
{
    public interface IUserInfoService : IBaseService<UserInfo>,IUserContext<string>
    {
        public Task<UserInfo> GetUserInfoByID(int id);

        public Task<IQueryable<UserInfo>> GetUserInfoByUser();
    }
}
