using Core.Services;
using 通用订票.Base.IService;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IStockService<T> : IBaseStockService<T>,IBaseService<T>  where T : Core.BaseEntity.Stock, new()
    {
        public Task<T> checkStock(string stockId);
        public Task<int?> GetSaled(string sotckId);
        public Task DelStockFromCache(string stockId);
    }
}
