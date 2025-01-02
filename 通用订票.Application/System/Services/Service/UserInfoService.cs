using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using Core.Services;
using Core.Utill.UniqueCode;
using Core.Auth;

namespace 通用订票.Application.System.Services.Service
{
    public class UserInfoService : BaseService<UserInfo,MasterDbContextLocator>, IUserInfoService, ITransient
    {
        private long userid { get; set; }
        private readonly IIdGenerater<long> idGenerater;

        public UserInfoService(IRepository<UserInfo, MasterDbContextLocator> dal, IIdGenerater<long> idGenerater)
        {
            this._dal = dal;
            this.idGenerater = idGenerater;
        }

        public void SetUserContext(long user)
        {
            userid = user;
        }

        public async Task<UserInfo> Add(UserInfo user)
        {
            user.userID = userid;
            user.id = await idGenerater.Generate("UserInfo");
            return await this.AddNow(user);
        }

        public async Task Update(UserInfo userinfo)
        {
            userinfo.userID = userid;
            await this.UpdateNow(userinfo);
        }

        public async Task<UserInfo> GetUserInfoByID(int id)
        {
            var entity = this.GetQueryableNt(a => a.id == id);
            return await entity.FirstOrDefaultAsync();
        }

        public async Task<ICollection<UserInfo>> GetUserInfoByUser()
        {
            var entity = await this.GetWithConditionNt(a => a.userID == userid);
            return entity;
        }
    }
}
