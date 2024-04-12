using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Entity
{
    public class XieChengConfig : IEntity, IEntityTypeBuilder<XieChengConfig>
    {
        public string Account { get; set; }
        public string ApiKey { get; set; }
        public string AESKey { get; set; }
        public string AESVector { get; set; }
        public const string CallUrl = "https://ttdopen.ctrip.com/api/order/notice.do";
        //https://ttdentry.ctrip.com/ttd-connect-orderentryapi/supplier/order/notice.do

        public void Configure(EntityTypeBuilder<XieChengConfig> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.Account);
        }

    }
}
