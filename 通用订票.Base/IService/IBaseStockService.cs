using 通用订票.Base.Entity;

namespace 通用订票.Base.IService
{
    public interface IBaseStockService<T> where T : StockAbstract,new()
    {
        /// <summary>
        /// 售卖减少库存
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        Task<T> SaleStock(string stockId,int count);
    }
}
