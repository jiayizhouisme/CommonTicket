using Core.Services;

namespace 通用订票.Application.System.ServiceBases.IService
{
    public interface IStockService<T> : 通用订票.Stock.IService.IBaseStockService<T>, IBaseService<T> where T : Core.BaseEntity.Stock, new()
    {
        public Task<T> checkStock(Guid stockId);
        public Task DelStockFromCache(Guid stockId);
    }
}
