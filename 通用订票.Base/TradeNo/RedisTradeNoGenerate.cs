using Core.Cache;
using Furion.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Base.TradeNo
{
    public class RedisTradeNoGenerate : ITradeNoGenerate<long>,ISingleton
    {
        private readonly ICacheOperation _cache;
        public RedisTradeNoGenerate(ICacheOperation _cache)
        {
            this._cache = _cache;
        }
        public async Task<long> Generate()
        {
            DateTime currentTime = DateTime.Now;
            string originDateStr = currentTime.ToString("yyMMdd");
            long differSecond = currentTime.Minute * 60 + currentTime.Second;

            string yyMMddSecond = originDateStr + differSecond.ToString().PadLeft(5, '0');
            var parsed = long.Parse(yyMMddSecond);

            long? res = await _cache.Get<long>("TradeNo");
            if (res == null)
            {
                await _cache.Set("TradeNo", 0, 60);
            }
            res = await _cache.Incr("TradeNo");

            //生成订单编号
            string orderNo = parsed.ToString() + res.ToString().PadLeft(4, '0');
            return long.Parse(orderNo);
        }
    }
}
