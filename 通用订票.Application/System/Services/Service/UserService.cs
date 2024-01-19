using Furion.DataEncryption.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using Core.Services;
using Core.User.Service;

namespace 通用订票.Application.System.Services.Service
{
    public class UserService : UserLoginService<User>, IUserService, ITransient
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }

        public virtual async Task<string[]> GetToken(User user, string extra_info)
        {
            var _user = await this.Login(user);
            if (_user == null)
            {
                return null;
            }
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "jti", _user.id},  // 存储Id
                { "name",_user.username }, // 存储用户名
                { "tenant-id",extra_info}
            }, 7200);
            // 获取刷新 token
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 43200); // 第二个参数是刷新 token 的有效期（分钟），默认三十天
            return new string[] { accessToken, refreshToken };
        }
    }
}
