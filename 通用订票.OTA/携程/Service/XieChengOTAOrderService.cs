using Core.Auth;
using Core.Cache;
using Core.Services;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.ServiceBases.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;
using 通用订票.Web.Entry.Controllers;
using 通用订票Order.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.OTA.携程.Service
{
    public class XieChengOTAOrderService :
        BaseService<XieChengOrder, MasterDbContextLocator>,
        IXieChengOTAOrderService
        , ITransient
    {
        private IDefaultOrderServices _orderServices { get; set; }
        private readonly IRepository<XieChengConfig,MasterDbContextLocator> configRep;
        private readonly ICacheOperation _cache;
        private readonly IServiceScopeFactory ScopeFactory;

        public XieChengOTAOrderService(
            IRepository<XieChengOrder, MasterDbContextLocator> _dal,
            IRepository<XieChengConfig, MasterDbContextLocator> configRep,
            ICacheOperation _cache,
            IServiceScopeFactory ScopeFactory
            )
        {
            base._dal = _dal;
            this.configRep = configRep;
            this._cache = _cache;
            this.ScopeFactory = ScopeFactory;
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }

        public async Task<XieChengPreOrderResponse> CreateXieChengOrder(XiechengCreateOrder _orders)
        {
            long supplierOrderId = 0;
            string locker = Guid.NewGuid().ToString();
            string key = "XieChengOrderLock:" + _orders.otaOrderId;
            await _cache.Lock(key, locker);
            if (await this.Exist(a => a.otaOrderId == _orders.otaOrderId))
            {
                supplierOrderId = await this.GetQueryableNt(a => a.otaOrderId == _orders.otaOrderId).Select(a => a.trade_no).FirstOrDefaultAsync();
            }
            else
            {
                var orders = _orders.items;
                var first = orders.First();
                var entity = await this._orderServices.CreateOrder(
                        Guid.Empty,
                        first.PLU,
                        first.quantity,
                        OrderStatus.未付款
                    );
                supplierOrderId = entity.trade_no;
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
                    order.passengerIds = string.Join(" ", order.passengers.Select(a => a.passengerId).ToArray());
                    await this.AddNow(order);
                }
            }
            await _cache.ReleaseLock(key, locker);
            return new XieChengPreOrderResponse
            {
                otaOrderId = _orders.otaOrderId,
                supplierOrderId = supplierOrderId.ToString()
            };
        }

        public async Task<XieChengOrder[]> QueryXieChengOrder(string otaOrderId)
        {
            var order = await this.GetQueryableNt(a => a.otaOrderId == otaOrderId).ToArrayAsync();
            return order;
        }

        public async Task<XieChengConfig> GetConfig(string tenant_id)
        {
            var key = "XieChengConfig:" + tenant_id;
            var config = await _cache.Get<XieChengConfig>(key);
            if (config == null) {
                config = await configRep.FirstOrDefaultAsync();
                await _cache.Set(key,config);
            }
            return config;
        }

        public async Task<string[]> GetPassengersIds(string otaOrderId, string itemId)
        {
            var order = this.GetQueryableNt(a => a.otaOrderId == otaOrderId && a.itemId == itemId).Select(a => a.passengerIds);
            return order.ToArray() ;

        }

        public async Task<bool> CanclePreOrder(string otaOrderId)
        {
            string key = "XieChengOrderLock:" + otaOrderId;
            string locker = Guid.NewGuid().ToString();
            await _cache.Lock(key, locker);
            var orders = await this.GetWithCondition(a => a.otaOrderId == otaOrderId);
            foreach (var order in orders)
            {
                if (order.orderStatus == XieChengOrderStatus.待支付)
                {
                    order.orderStatus = XieChengOrderStatus.预下单取消成功;
                    await this.UpdateNow(order);
                }
            }
            await _cache.ReleaseLock(key, locker);
            return true;
        }

        public async Task<XieChengPayPre> PayPreOrder(XiechengPayPreOrder order)
        {
            var orders = await this.GetWithCondition(a => a.otaOrderId == order.otaOrderId);
            string supplierOrderId = null;
            List<XieChengPayPreConfirmItems> itemList = new List<XieChengPayPreConfirmItems>();
            foreach (var item in order.items)
            {
                var first = orders.Where(a => a.PLU == item.PLU).FirstOrDefault();
                supplierOrderId = first.trade_no.ToString();
                if (first != null && first.orderStatus == XieChengOrderStatus.待支付)
                {
                    first.orderStatus = XieChengOrderStatus.支付待确认;
                    first.PLU = item.PLU;
                    first.itemId = item.itemId;
                    await this.UpdateNow(first);
                }

                itemList.Add(new XieChengPayPreConfirmItems()
                {
                    itemId = item.itemId,
                    isCredentialVouchers = 0
                });
            }

            var _body = new XieChengPayPre
            {
                voucherSender = 1,
                otaOrderId = order.otaOrderId,
                supplierOrderId = supplierOrderId,
                supplierConfirmType = 2,
                items = itemList
            };
            return _body;
        }

        public async Task<XieChengPayPreConfirm> PayPreConfirm(XiechengPayPreOrder data)
        {

            using (var scope = this.ScopeFactory.CreateScope())
            {
                #region 获取services
                var factory = SaaSServiceFactory.GetServiceFactory(data.tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenant_id);

                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var o_service = factory.GetOrderService(_orderProvider);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenant_id);

                var order = await o_service.GetOrderById(long.Parse(data.supplierOrderId));
                t_service.SetUserContext(Guid.Empty);
                #endregion
                XieChengPayPreConfirm confirm = new XieChengPayPreConfirm();
                confirm.otaOrderId = data.otaOrderId;
                confirm.supplierOrderId = data.supplierOrderId;
                confirm.confirmResultCode = 0;
                confirm.confirmResultMessage = "succes";
                confirm.voucherSender = 1;
                confirm.supplierConfirmType = data.supplierConfirmType;
                List<XieChengVouchers> ticketList = new List<XieChengVouchers>();
                List<XieChengPayPreConfirmItems> itemList = new List<XieChengPayPreConfirmItems>();

                string key = "XieChengOrderLock:" + data.otaOrderId;
                string locker = Guid.NewGuid().ToString();
                await _cache.Lock(key, locker);

                var xiechengOrders = await this.GetWithCondition(a => a.otaOrderId == data.otaOrderId);
                using (var trans = dbcontext.Database.BeginTransaction())
                {
                    foreach (var item in data.items)
                    {
                        ICollection<Ticket> tickets = null;
                        var _pluorder = xiechengOrders.Where(a => a.PLU == item.PLU).FirstOrDefault();
                        if (_pluorder.orderStatus == XieChengOrderStatus.支付已确认)
                        {
                            tickets = await t_service.GetTickets(order.trade_no);
                        }
                        else if(_pluorder.orderStatus == XieChengOrderStatus.待支付)
                        {
                            _pluorder.orderStatus = XieChengOrderStatus.支付已确认;
                            _pluorder.itemId = item.itemId;
                            await this.UpdateNow(_pluorder);
                            await o_service.PayFinished(order);
                            var passids = _pluorder.passengerIds.Split(" ");
                            var startTime = DateTime.Parse(_pluorder.useStartDate);
                            var endTime = DateTime.Parse(_pluorder.useEndDate);
                            
                            tickets = await t_service.GenarateTickets(startTime,
                                endTime,
                                order,
                                _pluorder.quantity,
                                passids,
                                item.itemId,
                                TicketStatus.未使用,
                                OTAType.XieCheng);

                        }
                        if (tickets != null)
                        {
                            foreach (var ticket in tickets)
                            {
                                ticketList.Add(new XieChengVouchers
                                {
                                    itemId = item.itemId,
                                    voucherId = ticket.ticketNumber,
                                    voucherCode = ticket.ticketNumber,
                                    voucherType = 3,
                                    voucherData = data.http_path + "/verify?id=" + ticket.ticketNumber
                                });
                            }
                        }
                        

                        itemList.Add(new XieChengPayPreConfirmItems()
                        {
                            itemId = item.itemId,
                            isCredentialVouchers = 0
                        });
                    }

                    await _cache.ReleaseLock(key, locker);

                    var config = await this.GetConfig(data.tenant_id);

                    confirm.vouchers = ticketList.ToArray();
                    confirm.sequenceId = data.sequenceId;
                    confirm.items = itemList.ToArray();
                    if (data.supplierConfirmType == 2)
                    {
                        var rawstr = XieChengTool.AESEncrypt(JsonConvert.SerializeObject(confirm), config.AESKey, config.AESVector);
                        var body = XieChengTool.EncodeBytes(rawstr);

                        XieChengRequest xr = new XieChengRequest();
                        xr.header = new XieChengHeader();
                        xr.header.requestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        xr.header.serviceName = "PayPreOrderConfirm";
                        xr.header.version = "1.0";
                        xr.header.accountId = config.Account;
                        xr.header.sign = MD5Encryption.Encrypt(
                            xr.header.accountId +
                            xr.header.serviceName +
                            xr.header.requestTime +
                            body +
                            xr.header.version +
                            config.ApiKey);
                        xr.body = body;
                        var response = await xr.Request();
                    }
                    await trans.CommitAsync();
                    return confirm;
                }
            }
        }

        public async Task<XieChengCancelOrderResponse> CancelOrder(XieChengCancelOrder order)
        {
            var xiechengOrders = await this.GetWithCondition(a => a.otaOrderId == order.otaOrderId);
            foreach (var xiechengOrder in xiechengOrders)
            {
                if (xiechengOrder.orderStatus == XieChengOrderStatus.支付已确认)
                {
                    xiechengOrder.orderStatus = XieChengOrderStatus.取消待确认;
                    await this.UpdateNow(xiechengOrder);
                }
            }

            return new XieChengCancelOrderResponse()
            {
                supplierConfirmType = 2
            };
        }

        public async Task<XieChengCancelOrderConfirm> CancleOrderConfirm(XieChengCancelOrder order)
        {
            XieChengCancelOrderConfirm confirm = new XieChengCancelOrderConfirm();
            List<XieChengCancelOrderReponseItems> itemList = new List<XieChengCancelOrderReponseItems>();
            using (var scope = this.ScopeFactory.CreateScope())
            {
                var factory = SaaSServiceFactory.GetServiceFactory(order.tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, order.tenant_id);

                var xiechengOrders = await this.GetWithCondition(a => a.otaOrderId == order.otaOrderId);
                if (xiechengOrders.Count == 0)
                {
                    confirm.confirmResultCode = "2001";
                    confirm.confirmResultMessage = "该订单号不存在";
                }
                foreach (var xiechengOrder in xiechengOrders)
                {
                    var data = order.items.Where(a => a.itemId == xiechengOrder.itemId).FirstOrDefault();
                    if (data.cancelType == 1 || data.cancelType == 0)
                    {
                        var ticket = await t_service.GetQueryable(a => a.itemId == data.itemId).FirstOrDefaultAsync();
                        if (data.quantity <= xiechengOrder.quantity)
                        {
                            xiechengOrder.cancelQuantity = data.quantity;
                            ticket.usedCount = xiechengOrder.cancelQuantity;
                            if (data.cancelType == 0)
                            {
                                
                                xiechengOrder.orderStatus = XieChengOrderStatus.全部取消;
                            }
                            else if(data.cancelType == 1)
                            {
                                xiechengOrder.orderStatus = XieChengOrderStatus.部分取消;
                            }
                            
                            await t_service.UpdateNow(ticket);
                            await this.UpdateNow(xiechengOrder);
                            confirm.confirmResultMessage = "确认成功";
                            confirm.confirmResultCode = "0000";
                        }
                        else
                        {
                            confirm.confirmResultMessage = "取消数量不正确";
                            confirm.confirmResultCode = "2004";
                        }
                        itemList.Add(new XieChengCancelOrderReponseItems
                        {
                            itemId = data.itemId,
                            vouchers = new XieChengVouchers[1] {
                                        new XieChengVouchers{ voucherId = ticket.ticketNumber}
                                    }
                        });
                    }
                }

                var config = await this.GetConfig(order.tenant_id);

                confirm.otaOrderId = order.otaOrderId;
                confirm.sequenceId = order.sequenceId;
                confirm.supplierOrderId = order.supplierOrderId.ToString();
                confirm.supplierConfirmType = order.supplierConfirmType;
                confirm.items = itemList;
                if (order.supplierConfirmType == 2)
                {
                    var rawstr = XieChengTool.AESEncrypt(JsonConvert.SerializeObject(confirm), config.AESKey, config.AESVector);
                    var body = XieChengTool.EncodeBytes(rawstr);
                    XieChengRequest xr = new XieChengRequest();
                    xr.header = new XieChengHeader();
                    xr.header.requestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xr.header.serviceName = "CancelOrderConfirm";
                    xr.header.version = "1.0";
                    xr.header.accountId = config.Account;
                    xr.header.sign = MD5Encryption.Encrypt(
                        xr.header.accountId +
                        xr.header.serviceName +
                        xr.header.requestTime +
                        body +
                        xr.header.version +
                        config.ApiKey);
                    xr.body = body;
                    var response = await xr.Request();
                }
            }
            return confirm;
        }
    }
}
