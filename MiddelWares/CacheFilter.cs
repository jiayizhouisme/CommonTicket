using Furion.DataEncryption.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.Cache;

namespace Core.MiddelWares
{
    public class CacheFilter : IResourceFilter
    {
        protected readonly MyBeetleX _cache;
        protected string suffixed;
        public static int _expireTime = 30;

        public CacheFilter(MyBeetleX _cache)
        {
            this._cache = _cache;
        }
        public virtual void OnResourceExecuting(ResourceExecutingContext context)
        {

            string path = context.HttpContext.Request.Host + context.HttpContext.Request.Path + 
                context.HttpContext.Request.QueryString.Value + suffixed;
            SetResult(context, path);
        }

        public virtual void OnResourceExecuted(ResourceExecutedContext context)
        {
            string path = context.HttpContext.Request.Host + context.HttpContext.Request.Path +
                context.HttpContext.Request.QueryString.Value + suffixed;
            this.SetCache(context, path);
        }

        protected virtual void SetCache(ResourceExecutedContext context, string key)
        {
            key = key.ToMD5Encrypt(false, true);
            if (this._cache.Get<object>(key).Result == null)
            {
                var result = this._cache.Set(key, (context.Result as ObjectResult)?.Value, _expireTime).Result;
            }
        }

        protected virtual void SetResult(ResourceExecutingContext context, string key)
        {
            key = key.ToMD5Encrypt(false, true);
            var result = this._cache.Get<object>(key).Result;
            if (result != null)
            {
                object obj = result;
                context.Result = new ObjectResult(obj);
            }
        }

    }
}