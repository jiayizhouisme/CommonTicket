using 通用订票.Stock.Entity;

namespace 订票系统.Rules.IService
{
    public interface IBaseStockRuleService<T> : IRuleService<T> where T : StockAbstract
    {
        
    }
}