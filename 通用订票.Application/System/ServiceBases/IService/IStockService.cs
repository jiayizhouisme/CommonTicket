using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using 通用订票.Stock.Entity;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IStockService<T> : 通用订票.Stock.IService.IBaseStockService<T>, IBaseService<T> where T : Core.BaseEntity.Stock, new()
    {
        public Task<T> checkStock(Guid stockId);
        public Task DelStockFromCache(Guid stockId);
    }
}
