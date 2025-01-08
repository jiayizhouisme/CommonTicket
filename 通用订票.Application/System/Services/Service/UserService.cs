using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using Core.User.Service;
using Core.Auth;
using Core.Utill.UniqueCode;
using Furion.DataEncryption;
using Core.Utill.Tools;
using Furion.RemoteRequest.Extensions;
using 通用订票.Application.System.Models;

namespace 通用订票.Application.System.Services.Service
{
    public class UserService : UserLoginService<User, MasterDbContextLocator>, IUserService, ITransient
    {
        private readonly IIdGenerater<long> idGenerater;
        public UserService(IIdGenerater<long> idGenerater,IRepository<User, MasterDbContextLocator> repository) : base(repository)
        {
            this.idGenerater = idGenerater;
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
                { "jti", _user.id.ToString()},  // 存储Id
                { "name",_user.username }, // 存储用户名
                { "tenant-id",extra_info},
                { "loginType","normal"},
                { "permissions",Permissions.Administrator}
            }, 7200);
            // 获取刷新 token
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 43200); // 第二个参数是刷新 token 的有效期（分钟），默认三十天
            return new string[] { accessToken, refreshToken };
        }

        public async Task<string[]> GetWechatToken(string openid, string extra_info)
        {
            openid = Tools.Decrypt(openid, "q0m3sd8l");
            
            var originOpenid = openid.Split(',')[0];
            var date = DateTime.Parse(openid.Split(',')[1]);
            var id = openid.Split(',')[2];
            if (date.AddMinutes(5).CompareTo(DateTime.Now) < 0)
            {
                throw new Exception("登录超时");
            }
            User user = await this.GetQueryableNt(a => a.openId == originOpenid).FirstOrDefaultAsync();
            if(user == null)
            {
                var result = await "http://umplatform.z2ww.com/api/WechatUser/GetWechatUser".SetQueries(new { openid = originOpenid }).GetAsAsync<WUser>();
                user = new User { username = result.NickName, password = "-1",openId = originOpenid };
                user = await this.RegisteNewUser(user);
            }

            if (user == null)
            {
                throw new Exception("用户登陆时发生错误");
            }
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                { "jti", user.id.ToString()},  // 存储Id
                { "name",user.username}, // 存储用户名
                { "openid",user.openId},
                { "loginType","wechat"},
                { "tenant-id",extra_info},
                { "permissions",Permissions.Normal}
            }, 7200);
            // 获取刷新 token
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 43200); // 第二个参数是刷新 token 的有效期（分钟），默认三十天
            return new string[] { accessToken, refreshToken };
        }

        public async Task<User> RegisteNewUser(User user)
        {
            var tsk = idGenerater.Generate("USER");
            user.authLevel = Permissions.Normal;
            user.isDeleted = false;
            user.CreateTime = DateTime.Now;
            user.id = await tsk;
            await this.AddNow(user);
            return user;
        }
    }
}
