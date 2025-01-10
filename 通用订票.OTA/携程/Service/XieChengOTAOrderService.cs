using Core.Auth;
using Core.Cache;
using Core.Services;
using Core.Services.ServiceFactory;
using Core.User.Service;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using StackExchange.Redis;
using System;
using System.Collections;
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
using 通用订票.Core.BaseEntity;
using 通用订票.Core.Entity;
using 通用订票.JobTask;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;
using 通用订票.Web.Entry.Controllers;
using 通用订票Order.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.OTA.携程.Service
{
    public class XieChengOTAOrderService :
        BaseService<XieChengOrder, MasterDbContextLocator>,
        IXieChengOTAOrderService
        , ITransient
    {
        private IDefaultOrderServices _orderServices;
        private readonly IXieChengOTATicketService xiechengTicketService;
        private readonly IRepository<XieChengConfig,MasterDbContextLocator> configRep;
        private readonly ICacheOperation _cache;
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly IExhibitionService exhibitionService;
        private readonly IEventPublisher eventPublisher;
        private string tenant_id { get; set; }

        public XieChengOTAOrderService(
            IRepository<XieChengOrder, MasterDbContextLocator> _dal,
            IRepository<XieChengConfig, MasterDbContextLocator> configRep,
            ICacheOperation _cache,
            IServiceScopeFactory ScopeFactory,
            IExhibitionService exhibitionService,
            IXieChengOTATicketService xiechengTicketService,
            IEventPublisher eventPublisher
            )
        {
            base._dal = _dal;
            this.configRep = configRep;
            this._cache = _cache;
            this.ScopeFactory = ScopeFactory;
            this.exhibitionService = exhibitionService;
            this.xiechengTicketService = xiechengTicketService;
            this.eventPublisher = eventPublisher;
        }

        public void SetService(IDefaultOrderServices service)
        {
            _orderServices = service;
        }

        public async Task<XieChengPreOrderResponse> CreateXieChengOrder(XiechengCreateOrder _orders)
        {
            using (var scope = this.ScopeFactory.CreateScope())
            {
                var factory = SaaSServiceFactory.GetServiceFactory(tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service,tenant_id);

                long supplierOrderId = 0;
                string locker = Guid.NewGuid().ToString();
                string key = "OrderLocker_" + _orders.otaOrderId;
                await _cache.Lock(key, locker);

                var __orders = await GetOrder(_orders.otaOrderId);
                if (__orders != null && __orders.Count > 0)
                {
                    supplierOrderId = __orders.Select(a => a.trade_no).FirstOrDefault();
                    var orders = await _cache.Del("XieChengOrders:" + _orders.otaOrderId);
                }
                else
                {
                    using (var trans = dbcontext.Database.BeginTransaction())
                    {
                        var orders = _orders.items;
                        var first = orders.First();
                        var entity = await this._orderServices.CreateOrder(
                                first.PLU,
                                first.PLU,
                                Guid.Parse(first.PLU),
                                first.quantity,
                                _orders.items.Length,
                                OrderStatus.未付款
                            );
                        supplierOrderId = entity.trade_no;
                        foreach (var order in orders)
                        {
                            var app = await s_service.GetAppointmentsByDateAllDay
                                (Guid.Parse(order.PLU), DateTime.Parse(order.useStartDate));
                            order.trade_no = supplierOrderId;
                            order.otaOrderId = _orders.otaOrderId;
                            order.orderStatus = XieChengOrderStatus.待支付;
                            order.cancelQuantity = 0;
                            order.useQuantity = 0;
                            order.itemId = "0";
                            order.createTime = DateTime.Now;
                            order.name = order.PLU;
                            order.objectId = app.id;
                            order.userId = "";
                            order.locale = "zh-CN";
                            order.passengerIds = string.Join(" ", order.passengers.Select(a => a.passengerId).ToArray());
                            await s_service.SaleStockAndUpdate(app.id, order.quantity);
                            await this.AddNow(order);
                            await _cache.PushToList("XieChengOrders:" + order.otaOrderId, order);
                            await trans.CommitAsync();
                        }

                        
                    }
                }
                await _cache.ReleaseLock(key, locker);
                return new XieChengPreOrderResponse
                {
                    otaOrderId = _orders.otaOrderId,
                    supplierOrderId = supplierOrderId.ToString()
                };
            }
        }

        public async Task<XieChengOrderQueryResponseWithHeader> QueryXieChengOrder(string otaOrderId)
        {
            XieChengOrderQueryResponseWithHeader xwh = new XieChengOrderQueryResponseWithHeader();

            XieChengOrderQueryResponse xr = new XieChengOrderQueryResponse();
            var orders = await GetOrder(otaOrderId);
            if (orders == null || orders.Count == 0)
            {
                xwh.header = new XieChengResponseHeader { resultCode = "4001", resultMessage = "该订单号不存在" };
                return xwh;
            }
            xr.otaOrderId = otaOrderId;
            foreach (var order in orders)
            {
                xr.supplierOrderId = order.trade_no.ToString();
                var tickets = await xiechengTicketService.GetQueryableNt(a => a.itemId == order.itemId).Include(a => a.ticket).ToArrayAsync();
                var items = new XieChengOrderQueryResponseItems
                {
                    itemId = order.itemId,
                    useStartDate = order.useStartDate,
                    useEndDate = order.useEndDate,
                    cancelQuantity = order.cancelQuantity,
                    orderStatus = order.orderStatus,
                    quantity = order.quantity,
                    useQuantity = order.useQuantity,
                };
                foreach (var ticket in tickets)
                {
                    XieChengOrderQueryPassengers pass = new XieChengOrderQueryPassengers
                    {
                        passengerId = ticket.OTAPassengerId,
                        passengerStatus = ticket.voucherStatus
                    };

                    XieChengOrderQueryVouchers vouchers = new XieChengOrderQueryVouchers
                    {
                        voucherId = ticket.ticket.ticketNumber,
                        voucherStatus = ticket.voucherStatus
                    };
                    items.passengers.Add(pass);
                    items.vouchers.Add(vouchers);
                }
                
                xr.items.Add(items);
            }
            xwh.body = xr;
            xwh.header = new XieChengResponseHeader { resultCode = "0000", resultMessage = "操作成功" };
            return xwh;
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

        public async Task<bool> CanclePreOrder(XieChengOrderQuery query)
        {
            using (var scope = ScopeFactory.CreateScope()) 
            {
                var factory = SaaSServiceFactory.GetServiceFactory(tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, tenant_id);

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, tenant_id);

                var orders = await GetOrder(query.otaOrderId);
                using (var trans = dbcontext.Database.BeginTransaction())
                {
                    string locker = Guid.NewGuid().ToString();
                    foreach (var order in orders)
                    {
                        string key = "OrderLocker_" + order.trade_no;
                        await _cache.Lock(key, locker);

                        if (order.orderStatus == XieChengOrderStatus.待支付)
                        {
                            order.orderStatus = XieChengOrderStatus.预下单取消成功;
                            await this.UpdateNow(order);
                            await s_service.SaleStockAndUpdate(order.objectId, -order.quantity);
                        }
                        await _cache.ReleaseLock(key, locker);
                    }
                    await trans.CommitAsync();
                }
                await _cache.Del("XieChengOrders:" + query.otaOrderId);
                
            }
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

        public async Task<XieChengPayPreConfirmResponseWithHeader> PayPreConfirm(XiechengPayPreOrder data)
        {
            using (var scope = this.ScopeFactory.CreateScope())
            {
                #region 获取services
                var factory = SaaSServiceFactory.GetServiceFactory(tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, tenant_id);

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, tenant_id);
               
                var order = await _orderServices.GetOrderById(long.Parse(data.supplierOrderId));
                t_service.SetUserContext(-1);
                xiechengTicketService.SetService(t_service);
                #endregion
                XieChengPayPreConfirmResponseWithHeader wh = new XieChengPayPreConfirmResponseWithHeader();
                XieChengResponseHeader xh = new XieChengResponseHeader();
                xh.resultCode = "0000";
                xh.resultMessage = "succeed";
                XieChengPayPreConfirm confirm = new XieChengPayPreConfirm();
                List<XieChengVouchers> ticketList = new List<XieChengVouchers>();
                List<XieChengPayPreConfirmItems> itemList = new List<XieChengPayPreConfirmItems>();

                string key = "OrderLocker_" + data.supplierOrderId;
                string locker = Guid.NewGuid().ToString();
                await _cache.Lock(key, locker);
                
                var xiechengOrders = await GetOrder(data.otaOrderId);
                using (var trans = dbcontext.Database.BeginTransaction())
                {
                    foreach (var item in data.items)
                    {
                        var _pluorder = xiechengOrders.Where(a => a.PLU == item.PLU).FirstOrDefault();
                        var exhibition = await exhibitionService.GetExhibitionByID(Guid.Parse(item.PLU));
                        var stock = await s_service.GetAppointmentsByDateAllDay(exhibition.id,
                            DateTime.Parse(_pluorder.useStartDate));
                        if (stock == null || exhibition == null)
                        {
                            xh.resultCode = "1001";
                            xh.resultMessage = "产品PLU不存在/错误";
                            return wh;
                        }

                        List<Ticket> tickets = new List<Ticket>();
                        if (_pluorder.orderStatus == XieChengOrderStatus.支付已确认)
                        {
                            tickets.AddRange(await t_service.GetTickets(order.trade_no));
                        }
                        else if (_pluorder.orderStatus == XieChengOrderStatus.待支付)
                        {
                            _pluorder.orderStatus = XieChengOrderStatus.支付已确认;
                            _pluorder.itemId = item.itemId;

                            var passids = _pluorder.passengerIds.Split(" ");

                            if (exhibition.passType == PassTemplate.一单一人)
                            {
                                var _ = await xiechengTicketService.CreateTicket(exhibition,stock, _pluorder, order);
                                tickets.Add(_);
                            }
                            else if (exhibition.passType == PassTemplate.一张一人)
                            {
                                var _ = await xiechengTicketService.CreateTicket(exhibition,stock, _pluorder, order, passids);
                                tickets.AddRange(_);
                            }

                            await this.UpdateNow(_pluorder);
                            await _orderServices.PayFinished(order);
                        }
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

                        itemList.Add(new XieChengPayPreConfirmItems()
                        {
                            itemId = item.itemId,
                            isCredentialVouchers = 0
                        });
                    }
                    await trans.CommitAsync();
                }
                await _cache.Del("XieChengOrders:" + data.otaOrderId);
                await _cache.ReleaseLock(key, locker);

                var config = await this.GetConfig(tenant_id);

                confirm.vouchers = ticketList.ToArray();
                confirm.sequenceId = data.sequenceId;
                confirm.items = itemList.ToArray();
                confirm.otaOrderId = data.otaOrderId;
                confirm.supplierOrderId = data.supplierOrderId;
                confirm.confirmResultCode = 0;
                confirm.confirmResultMessage = "success";
                confirm.voucherSender = 1;
                confirm.supplierConfirmType = data.supplierConfirmType;
                wh.body = confirm;
                wh.header = xh;

                return wh;
                
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
                
                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, order.tenant_id);
                this.xiechengTicketService.SetService(t_service);
                var xiechengOrders = await GetOrder(order.otaOrderId);
                if (xiechengOrders.Count == 0)
                {
                    confirm.confirmResultCode = "2001";
                    confirm.confirmResultMessage = "该订单号不存在";
                }
                string key = "OrderLocker_" + order.supplierOrderId;
                string locker = Guid.NewGuid().ToString();
                await _cache.Lock(key, locker);
                using (var trans = dbcontext.Database.BeginTransaction())
                {
                    foreach (var xiechengOrder in xiechengOrders)
                    {
                        var exhibition = await exhibitionService.GetExhibitionByID(Guid.Parse(xiechengOrder.PLU));

                        var data = order.items.Where(a => a.itemId == xiechengOrder.itemId).FirstOrDefault();
                        List<XieChengVouchers> vouchers = new List<XieChengVouchers>();

                        if (xiechengOrder.orderStatus == XieChengOrderStatus.全部使用 ||
                            xiechengOrder.orderStatus == XieChengOrderStatus.部分使用)
                        {
                            confirm.confirmResultCode = "2002";
                            confirm.confirmResultMessage = "该订单已经使用";
                            return confirm;
                        }

                        if (data.quantity > (xiechengOrder.quantity - xiechengOrder.useQuantity))
                        {
                            confirm.confirmResultMessage = "取消数量不正确";
                            confirm.confirmResultCode = "2004";
                            return confirm;
                        }

                        if (data.cancelType == 0)
                        {
                            xiechengOrder.orderStatus = XieChengOrderStatus.全部取消;
                        }
                        else if (data.cancelType == 1 || data.cancelType == 2)
                        {
                            xiechengOrder.orderStatus = XieChengOrderStatus.部分取消;
                        }
                        xiechengOrder.cancelQuantity = data.quantity;
                        var tickets = await xiechengTicketService.GetQueryable(a => a.itemId == data.itemId).Include(a => a.ticket).ToListAsync();
                        if (exhibition.passType == PassTemplate.一单一人)
                        {
                            int cancelCount = 0;
                            
                            foreach (var ticket in tickets)
                            {
                                if (ticket.ticket.isMultiPart == true)
                                {
                                    var result = await this.xiechengTicketService.CancelTicket
                                                  (ticket.ticket.ticketNumber, data.quantity);
                                    if (result.code == 0)
                                    {
                                        confirm.confirmResultCode = "2002";
                                        confirm.confirmResultMessage = result.message;
                                        await _cache.ReleaseLock(key, locker);
                                        return confirm;
                                    }
                                }
                                cancelCount += data.quantity - ticket.ticket.cancelCount;
                                ticket.ticket.cancelCount = data.quantity;
                                if (ticket.ticket.cancelCount == ticket.ticket.totalCount)
                                {
                                    ticket.ticket.stauts = TicketStatus.已冻结;
                                    ticket.voucherStatus = 2;
                                    await _cache.Del("Ticket:" + ticket.ticket.ticketNumber);
                                    vouchers.Add(new XieChengVouchers { voucherId = ticket.ticket.ticketNumber });
                                }
                            }
                            await xiechengTicketService.UpdateNow(tickets);
                            if (cancelCount > 0)
                            {
                                await s_service.SaleStockAndUpdate(xiechengOrder.objectId, -cancelCount);
                            }
                        }
                        else if (exhibition.passType == PassTemplate.一张一人)
                        {
                            if (data.cancelType == 0)
                            {
                                int usedCount = 0;
                                foreach (var ticket in tickets)
                                {
                                    if (ticket.ticket.stauts != TicketStatus.已冻结)
                                    {
                                        if (ticket.ticket.isMultiPart == true)
                                        {
                                            var result = await this.xiechengTicketService.CancelTicket
                                                          (ticket.ticket.ticketNumber, 1);
                                            if (result.code == 0)
                                            {
                                                confirm.confirmResultCode = "2002";
                                                confirm.confirmResultMessage = result.message;
                                                await _cache.ReleaseLock(key, locker);
                                                return confirm;
                                            }
                                        }
                                        ticket.ticket.stauts = TicketStatus.已冻结;
                                        ticket.ticket.cancelCount = 1;
                                        ticket.voucherStatus = 2;
                                        usedCount++;
                                        await _cache.Del("Ticket:" + ticket.ticket.ticketNumber);
                                    }
                                    vouchers.Add(new XieChengVouchers { voucherId = ticket.ticket.ticketNumber });
                                }
                                await xiechengTicketService.UpdateNow(tickets);
                                await s_service.SaleStockAndUpdate(xiechengOrder.objectId, -usedCount);
                            }
                            else
                            {
                                int usedCount = 0;
                                foreach (var pass in data.passengers)
                                {
                                    var ticket = tickets.Where(a => a.OTAPassengerId == pass.passengerId).FirstOrDefault();
                                    if (ticket.ticket.stauts != TicketStatus.已冻结)
                                    {
                                        if (ticket.ticket.isMultiPart == true)
                                        {
                                            var result = await this.xiechengTicketService.CancelTicket
                                                          (ticket.ticket.ticketNumber, ticket.ticket.totalCount);
                                            if (result.code == 0)
                                            {
                                                confirm.confirmResultCode = "2002";
                                                confirm.confirmResultMessage = result.message;
                                                await _cache.ReleaseLock(key, locker);
                                                return confirm;
                                            }
                                        }

                                        ticket.ticket.stauts = TicketStatus.已冻结;
                                        ticket.ticket.cancelCount = ticket.ticket.totalCount;
                                        ticket.voucherStatus = 2;
                                        usedCount++;
                                        await _cache.Del("Ticket:" + ticket.ticket.ticketNumber);
                                    }
                                    vouchers.Add(new XieChengVouchers { voucherId = ticket.ticket.ticketNumber });
                                }
                                await xiechengTicketService.UpdateNow(tickets);
                                await s_service.SaleStockAndUpdate(xiechengOrder.objectId, -usedCount);

                            }
                        }

                        itemList.Add(new XieChengCancelOrderReponseItems
                        {
                            itemId = data.itemId,
                            vouchers = vouchers.ToArray()
                        });
                        confirm.confirmResultMessage = "确认成功";
                        confirm.confirmResultCode = "0000";

                        await this.UpdateNow(xiechengOrder);
                    }
                    await trans.CommitAsync();
                }
                await _cache.ReleaseLock(key, locker);
            }
            await _cache.Del("XieChengOrders:" + order.otaOrderId);
            var config = await this.GetConfig(order.tenant_id);

            confirm.otaOrderId = order.otaOrderId;
            confirm.sequenceId = order.sequenceId;
            confirm.supplierOrderId = order.supplierOrderId.ToString();
            confirm.supplierConfirmType = order.supplierConfirmType;
            confirm.items = itemList;
            return confirm;
        }

        public async Task<XieChengTIcketVerifyResult> Verify(string ticket_number, int useCount,string exhibitionId)//这里的是子项的ID
        {
            XieChengTicket ticket = null;
            XieChengOrder xiechengOrder = null;
            using (var scope = this.ScopeFactory.CreateScope())
            {
                #region 获取services
                var factory = SaaSServiceFactory.GetServiceFactory(tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, tenant_id);

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>(scope.ServiceProvider, s_service, tenant_id);
                t_service.SetUserContext(-1);
                xiechengTicketService.SetService(t_service);
                #endregion
                ticket = await xiechengTicketService.GetTicket(ticket_number);
                xiechengOrder = await this.GetQueryable(a => a.trade_no == ticket.ticket.objectId).FirstOrDefaultAsync();

                var result = await xiechengTicketService.TicketVerify(ticket, useCount, exhibitionId);

                if(result.shouldUpdate == false){
                    return result;
                }
                var app = await s_service.GetAppointmentById(ticket.ticket.AppointmentId);
                var exhibition = await exhibitionService.GetExhibitionByID(app.objectId);//不要弄混了，这里的exhibition是联票的ID
                if (result.code == 1)
                {
                    ticket = result.ticket;
                    if (exhibition.passType == PassTemplate.一张一人)
                    {
                        xiechengOrder.useQuantity += ticket.ticket.usedCount;
                    }
                    else if(exhibition.passType == PassTemplate.一单一人)
                    {
                        xiechengOrder.useQuantity = ticket.ticket.usedCount;
                    }
                        
                    if (xiechengOrder.useQuantity == xiechengOrder.quantity)
                    {
                        xiechengOrder.orderStatus = XieChengOrderStatus.全部使用;
                    }
                    else
                    {
                        xiechengOrder.orderStatus = XieChengOrderStatus.部分使用;
                    }
                    await this.UpdateNow(xiechengOrder);

                    await eventPublisher.PublishDelayAsync("UploadConsumeEvent", 30000,
                       new XieChengTicketVerifyEvent
                       {
                           tenant_id = this.tenant_id,
                           xiechengOrder = xiechengOrder,
                           xiechengTicket = ticket
                       });
                }
                return result;
            }
            
        }

        public void SetTenant(string tenant_id)
        {
            this.tenant_id = tenant_id;
        }

        public async Task<ICollection<XieChengOrder>> GetOrder(string otaOrderId)
        {
            string key = "XieChengOrders:" + otaOrderId;
            var orders = await _cache.GetList<XieChengOrder>(key, 0);
            if (orders == null || orders.Count == 0)
            {
                orders = await this.GetWithConditionNt(a => a.otaOrderId == otaOrderId);
                foreach (var order in orders)
                {
                    await _cache.PushToList(key,order);
                }
                await _cache.Expire(key,6000);
            }
            return orders;
        }
    }
}
