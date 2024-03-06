using Core.Services;
using 通用订票.Base.IService;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IStockService<T> : IBaseStockService<T>where T : Core.BaseEntity.Stock, new()
    {
        public Task<T> checkStock(Guid stockId);
        public Task DelStockFromCache(Guid stockId);
    }
}
