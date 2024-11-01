using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace 通用订票.Core.Entity
{
    [Comment("游客信息")]
    public class UserInfo : IEntity
    {
        public long id { get; set; }
        [Comment("姓名")]
        public string name { get; set; }
        [Comment("手机号")]
        public string phoneNumber { get; set; }
        [Comment("身份证")]
        public string idCard { get; set; }
        [Comment("创建时间")]
        public DateTime createTime { get; set; }
        [Comment("用户ID")]
        public long userID { get; set; }

        public void Configure(EntityTypeBuilder<UserInfo> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.id);
        }

      
    }
}
