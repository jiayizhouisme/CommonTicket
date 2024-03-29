using Core.Services;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;
using 通用订票Order.Entity;

namespace 通用订票.OTA.携程.Service
{
    public class XieChengOTAOrderService :
        BaseService<XieChengOrder, MasterDbContextLocator>,
        IXieChengOTAOrderService
        , ITransient
    {
        private IDefaultOrderServices _orderServices { get; set; }

        public XieChengOTAOrderService(IRepository<XieChengOrder, MasterDbContextLocator> _dal)
        {
            base._dal = _dal;
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }

        public async Task<XieChengOrder[]> CreateXieChengOrder(XiechengCreateOrder _orders)
        {
            var orders = _orders.items;
            var first = orders.First();
            Guid plu = Guid.Empty;
            if (!string.IsNullOrEmpty(first.PLU))
            {
                plu = Guid.Parse(first.PLU);
            }
            var entity = await this._orderServices.CreateOrder(
                    plu,
                    first.PLU,
                    first.quantity,
                    OrderStatus.未付款
                );
            foreach (var order in orders)
            {
                order.trade_no = entity.trade_no;
                order.otaOrderId = _orders.otaOrderId;
                order.orderStatus = XieChengOrderStatus.待支付;
                order.cancelQuantity = 0;
                order.useQuantity = 0;
                order.itemId = "0";
                order.createTime = DateTime.Now;
                order.name = first.PLU;
                order.objectId = first.PLU;
                order.userId = "";
                order.locale = "zh-CN";
                await this.AddNow(order);
            }
            return orders;
        }

        public async Task<XieChengOrder[]> QueryXieChengOrder(string otaOrderId)
        {
            var order = await this.GetQueryableNt(a => a.otaOrderId == otaOrderId).ToArrayAsync();
            return order;
        }
    }
}
