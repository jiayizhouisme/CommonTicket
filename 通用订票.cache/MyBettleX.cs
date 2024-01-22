using BeetleX.Redis;
using BeetleX.Redis.Commands;
using Furion;
using Furion.DataEncryption.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public class MyBeetleX : RedisDB
    {
        private RedisHost redisHost;
        public MyBeetleX()
        {
            redisHost = this.Host.AddWriteHost(App.Configuration["BeetleXConnectionString:Host"]);
            redisHost.Password = App.Configuration["BeetleXConnectionString:Password"];
            redisHost.MaxConnections = 500;
            this.KeyPrefix = App.Configuration["ServerConfig:CachePrefix"];
            this.DataFormater = new JsonFormater();
        }

        public async Task<long> Lock(string key, object value,int expireTime = 10)
        {
            var result = await this.SetNX(key, value);
            while (result != 1)
            {
                await Task.Delay(200);
                result = this.SetNX(key, value).Result;
            }
            await this.Expire(key, expireTime);
            return result;
        }

        public async Task<long> LockNoWait(string key, object value,int expireTime = 10)
        {
            var result = await this.SetNX(key, value);
            if (result != 1)
            {
                return 0;
            }
            await this.Expire(key, expireTime);
            return 1;
        }

        public async Task<long> ReleaseLock(string key, string value)
        {
            if (value != null)
            {
                var result = await this.Get<string>(key);
                if (result != null && result.CompareTo(value) == 0)
                {
                    return await this.Del(key);
                }
                else
                {
                    return 0;
                }
            }
            return await this.Del(key);
        }

        public async ValueTask<string> Set(string key, object value)
        {
            return await base.Set(key, value, null, null);
        }

        public async ValueTask<string> Set(string key, object value, int? extime)
        {
            return await base.Set(key, value, extime, null);
        }

        public async ValueTask<long> Del(params string[] key)
        {
            return await base.Del(key);
        }

        public async ValueTask<T> Get<T>(string key)
        {
            return await base.Get<T>(key);
        }
        public RedisList<T> CreateList<T>(string key)
        {
            return base.CreateList<T>(key);
        }

    }
}
