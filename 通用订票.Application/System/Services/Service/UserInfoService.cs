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
            if (user.id != Guid.Empty)
            {
                user.userID = userid;
                await this.UpdateNow(user);
            }
            else
            {
                user.id = Guid.NewGuid();
                user.userID = userid;
                return await this.AddNow(user);
            }
            return user;
        }

        public async Task<UserInfo> GetUserInfoByID(Guid id)
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
