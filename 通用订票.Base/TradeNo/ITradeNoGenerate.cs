using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Base.TradeNo
{
    public interface ITradeNoGenerate<T>
    {
        Task<T> Generate();
    }
}
