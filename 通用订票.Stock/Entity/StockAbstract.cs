using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Stock.Entity
{
    public abstract class StockAbstract
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string stockName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int amount { get; set; }
        public int sale { get; set; }
    }
}
