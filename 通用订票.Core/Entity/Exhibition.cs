using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using 通用订票.Core.Model;

namespace 通用订票.Core.Entity
{
    public class Exhibition :IEntity,IEntityTypeBuilder<Exhibition>
    {
        public Guid id { get; set; }
        [Comment("景区名")]
        public string name{ get;set;}
        [Comment("景区介绍")]
        public string description { get;set;}
        [Comment("景区封面")]
        public string imgs { get; set; }
        public int status { get; set; }
        [NotNull]
        [Comment("景区提前预约天数")]
        public int beforeDays { get; set; }
        [NotNull]
        public bool isDeleted { get; set; }
        [Comment("创建日期")]
        public DateTime createTime { get; set; }
        [Comment("价格")]
        public decimal basicPrice { get; set; }
        [NotNull]
        public PassTemplate passType { get; set; }
        public string exhibitions { get; set; }
        [NotNull]
        public bool isMultiPart { get; set; }
        public string forbiddenRule { get; set; }
        [Comment("一天最大预约人数")]
        public int totalAmount { get; set; }
        public void Configure(EntityTypeBuilder<Exhibition> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasQueryFilter(x => x.isDeleted == false);
        }

        public ForbiddenRule GetForbiddenRule()
        {
            if (forbiddenRule != null)
            {
                return JsonConvert.DeserializeObject<ForbiddenRule>(forbiddenRule);
            }
            return null;
        }
    }
    public enum PassTemplate
    {
        一张一人 = 0,
        一单一人 = 1
    }
}
