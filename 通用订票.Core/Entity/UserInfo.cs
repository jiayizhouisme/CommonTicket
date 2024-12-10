using Furion.DatabaseAccessor;
using Furion.DataValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace 通用订票.Core.Entity
{
    [Comment("游客信息")]
    public class UserInfo : IEntity
    {
        public long id { get; set; }
        [Comment("姓名")]
        public string name { get; set; }
        [Comment("手机号")]
        [DataValidation(ValidationTypes.PhoneNumber, ErrorMessage = "手机号格式错误")]
        public string phoneNumber { get; set; }
        [Comment("身份证")]
        [DataValidation(ValidationTypes.IDCard, ErrorMessage = "身份证格式错误")]
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
