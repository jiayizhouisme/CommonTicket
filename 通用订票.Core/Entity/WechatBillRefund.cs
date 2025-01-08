using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Entity
{
    public partial class WechatBillRefund : IEntity<MasterDbContextLocator>, IEntityTypeBuilder<WechatBillRefund>
    {
        /// <summary>
        /// 退款单表
        /// </summary>
        public WechatBillRefund()
        {
        }

        /// <summary>
        /// 退款单ID
        /// </summary>
        [Display(Name = "退款单ID")]
        public long refundId { get; set; }
        /// <summary>
        /// 售后单id
        /// </summary>
        [Display(Name = "售后单id")]
        [StringLength(20, ErrorMessage = "【{0}】不能超过{1}字符长度")]
        public System.String? aftersalesId { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        [Display(Name = "退款金额")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Decimal? money { get; set; }
        /// <summary>
        /// 用户ID 关联user.id
        /// </summary>
        [Display(Name = "用户ID 关联user.id")]
        public System.Int32? userId { get; set; }
        /// <summary>
        /// 资源id，根据type不同而关联不同的表
        /// </summary>
        [Display(Name = "资源id，根据type不同而关联不同的表")]
        [StringLength(20, ErrorMessage = "【{0}】不能超过{1}字符长度")]
        public System.String? sourceId { get; set; }

        /// <summary>
        /// 退款支付类型编码 默认原路返回 关联支付单表支付编码
        /// </summary>
        [Display(Name = "退款支付类型编码 默认原路返回 关联支付单表支付编码")]
        [StringLength(50, ErrorMessage = "【{0}】不能超过{1}字符长度")]
        public System.String? paymentCode { get; set; }
        /// <summary>
        /// 第三方平台交易流水号
        /// </summary>
        [Display(Name = "第三方平台交易流水号")]
        [StringLength(50, ErrorMessage = "【{0}】不能超过{1}字符长度")]
        public long tradeNo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        [Required(ErrorMessage = "请输入{0}")]
        public RefundStatus? status { get; set; }
        /// <summary>
        /// 退款失败原因
        /// </summary>
        [Display(Name = "退款失败原因")]
        public System.String? memo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.DateTime? createTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public System.DateTime? updateTime { get; set; }

        public void Configure(EntityTypeBuilder<WechatBillRefund> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.refundId);
            entityBuilder.HasIndex(a => a.tradeNo);
        }

    }
    public enum RefundStatus
    {
        未退款,
        已退款,
        退款失败
    }
}
