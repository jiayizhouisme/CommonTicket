﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using 通用订票.Order.Entity;

namespace 通用订票.Core.Entity
{
    public class Order : OrderBase<long>,IEntity, IEntityTypeBuilder<Order>
    {
        public DateTime? createTime { get; set; }
        public string extraInfo { get; set; }
        public void Configure(EntityTypeBuilder<Order> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasKey(a => a.trade_no);

        }
        public OrderInfo GetExtraInfo() {
            if (extraInfo != null)
            {
                return JsonConvert.DeserializeObject<OrderInfo>(extraInfo);
            }
            return null;
        }
    }

    public class OrderInfo
    {
        public string appid { get; set; }
        public int[] ids { get; set; }
    }
}

