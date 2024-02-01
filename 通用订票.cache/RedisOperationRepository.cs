using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Cache
{
    public class RedisOperationRepository : ICacheOperation
    {
        private readonly ILogger<RedisOperationRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly StackExchange.Redis.IDatabase _database;

        public RedisOperationRepository(ILogger<RedisOperationRepository> logger, ConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
            _database = redis.GetDatabase();
        }
        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }

        public async Task Clear()
        {
            foreach (var endPoint in _redis.GetEndPoints())
            {
                var server = GetServer();
                foreach (var key in server.Keys())
                {
                    await _database.KeyDeleteAsync(key);
                }
            }
        }
        public async ValueTask<long> Lock(string key, string value, int expireTime = 10)
        {
            var _lock = await this._database.LockTakeAsync(key, value, TimeSpan.FromSeconds(expireTime));
            while (_lock != true)
            {
                await Task.Delay(200);
                _lock = await this._database.LockTakeAsync(key, value, TimeSpan.MaxValue);
            }
            return 1;
        }

        public async ValueTask<long> LockNoWait(string key, string value, int expireTime = 10)
        {
            long result;
            var ret = await this._database.LockQueryAsync(key);
            ret.TryParse(out result);
            return result;
        }

        public async ValueTask<long> ReleaseLock(string key, string value)
        {
            var _lock = await this._database.LockReleaseAsync(key,value);
            if (_lock == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async ValueTask<string> Set(string key, object value)
        {
            string ret = null;
            if (value != null)
            {   ret = JsonConvert.SerializeObject(value);
                await _database.StringSetAsync(key, JsonConvert.SerializeObject(value));
            }
            return ret;
        }

        public async ValueTask<string> Set(string key, object value, int? extime)
        {
            string ret = null;
            if (value != null)
            {
                ret = JsonConvert.SerializeObject(value);
                await _database.StringSetAsync(key, ret,TimeSpan.FromSeconds(extime.Value));
            }
            return ret;
        }

        public async ValueTask<long> Del(params string[] key)
        {
            var _lock = await _database.KeyDeleteAsync(key[0]);
            if (_lock == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async ValueTask<T> Get<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                return default(T);
            }
        }

        public async ValueTask<long> Expire(string key, int extime)
        {
            var ret = await _database.KeyExpireAsync(key,TimeSpan.FromSeconds(extime));
            if (ret == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async ValueTask<long> PushToList<T>(string key, T value)
        {
            return await _database.ListRightPushAsync(key, JsonConvert.SerializeObject(value));
        }

        public async ValueTask<ICollection<T>> GetList<T>(string key, int start)
        {
<<<<<<< HEAD
            var result = await _database.ListRangeAsync(key, start, 1);
=======
            var length = await _database.ListLengthAsync(key);
            var result = await _database.ListRangeAsync(key, start, length);
>>>>>>> 缓存更改
            var list = result.Select(o => JsonConvert.DeserializeObject<T>(o)).ToList();
            return list;
        }

        public async ValueTask<long> Incrby(string key, int num)
        {
            return await _database.StringIncrementAsync(key,num);
        }

        public async ValueTask<long> Decrby(string key, int num)
        {
            return await _database.StringDecrementAsync(key,num);
        }

        public async ValueTask<long> Incr(string key)
        {
            return await _database.StringIncrementAsync(key);
        }

        public async ValueTask<long> Decr(string key)
        {
            return await _database.StringDecrementAsync(key);
        }
    }
}
