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
        public string name{ get;set;}
        public string description { get;set;}
        public string imgs { get; set; }
        public int status { get; set; }
        [NotNull]
        public int beforeDays { get; set; }
        [NotNull]
        public bool isDeleted { get; set; }
        public DateTime createTime { get; set; }
        public decimal basicPrice { get; set; }
        [NotNull]
        public PassTemplate passType { get; set; }
        public string exhibitions { get; set; }
        [NotNull]
        public bool isMultiPart { get; set; }
        public string forbiddenRule { get; set; }

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
