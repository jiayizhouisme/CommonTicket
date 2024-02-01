using BeetleX.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public interface ICacheOperation
    {
        ValueTask<long> Lock(string key, string value, int expireTime = 10);

        ValueTask<long> LockNoWait(string key, string value, int expireTime = 10);

        ValueTask<long> ReleaseLock(string key, string value);

        ValueTask<string> Set(string key, object value);

        ValueTask<string> Set(string key, object value, int? extime);
        ValueTask<long> Del(params string[] key);
        ValueTask<T> Get<T>(string key);
        ValueTask<long> Expire(string key,int extime);
        ValueTask<long> PushToList<T>(string key,T value);

        /// <summary>
        /// 一次拿去列表中所有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键值</param>
        /// <param name="start">起始位置</param>
        /// <returns></returns>
        ValueTask<ICollection<T>> GetList<T>(string key, int start);
        ValueTask<long> Incrby(string key, int num);
        ValueTask<long> Decrby(string key,int num);
        ValueTask<long> Incr(string key);
        ValueTask<long> Decr(string key);
    }
}
