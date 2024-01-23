using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using Core.Services;

namespace 通用订票.Application.System.Services.Service
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService, ITransient
    {
        private Guid userid { get; set; }

        public UserInfoService(IRepository<UserInfo> dal)
        {
            this._dal = dal;
        }

        public void SetUserContext(Guid user)
        {
            userid = user;
        }

        public async Task<UserInfo> Add(UserInfo user)
        {
            user.userID = userid;
            return await this.AddNow(user);
        }

        public async Task<UserInfo> GetUserInfoByID(int id)
        {
            var entity = this.GetQueryableNt(a => a.id == id);
            return await entity.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<UserInfo>> GetUserInfoByUser()
        {
            var entity = this.GetQueryableNt(a => a.userID == userid);
            return entity;
        }
    }
}
