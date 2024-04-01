using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using 通用订票.Order.Entity;

namespace 通用订票.OTA.携程.Entity
{
    public class XieChengOrder : OrderBase<string>, IEntity, IEntityTypeBuilder<XieChengOrder>
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string otaOrderId { get; set; }
        public string PLU { get; set; }
        public string locale { get; set; }
        public DateTime? createTime { get; set; }
        /// <summary>
        /// 用户选择的使用日期
        /// </summary>
        public string useStartDate { get; set; }
        /// <summary>
        /// 最晚可用日期
        /// </summary>
        public string useEndDate { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public int quantity { get; set; }
        public string itemId { get; set; }
        public int cancelQuantity { get; set; }
        public int useQuantity { get; set; }
        public string passengerIds { get; set; }
        public XieChengOrderStatus orderStatus { get; set; }
        [NotMapped]
        public XieChengPassenger[] passengers { get; set; }

        public void Configure(EntityTypeBuilder<XieChengOrder> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.otaOrderId);
        }
    }

    public enum XieChengOrderStatus
    {
        新订待确认 = 1,
        新订已确认,
        取消待确认,
        部分取消,
        全部取消,
        已取物品,
        部分使用,
        全部使用,
        已还物品,
        已过期,
        待支付,
        支付待确认,
        支付已确认,
        预下单取消成功
    }
}

