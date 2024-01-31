using 通用订票.Stock.Entity;

namespace 通用订票.Stock.IService
{
    public interface IBaseStockService<T> where T : StockAbstract,new()
    {
        /// <summary>
        /// 售卖减少库存
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        Task<T> SaleStock(Guid stockId,int count);
    }
}
