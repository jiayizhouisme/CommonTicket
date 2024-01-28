using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using Core.Cache;
using 通用订票.Core.Entity;
using Core.SignalR;
using Core.Auth;
using 通用订票Order.Entity;
using Core.MiddelWares;
using Furion.DependencyInjection;
using 通用订票.Application.System.Factory.Service;
using Core.Queue.IQueue;
using 通用订票.RedisMQ.Entity;
using 通用订票.Core.BaseEntity;

namespace 通用订票.Web.Entry.Controllers
{
    public class OrderController : IDynamicApiController
    {
        private readonly IUserInfoService userinfoService;
        private readonly IUserService userService;
        private readonly IAppointmentService stockService;
        private readonly IMyTicketService ticketService;
        private readonly IMyOrderServices myOrderService;
        private readonly IHttpContextUser httpContextUser;
        private readonly IWechatBillService billService;
        private readonly IExhibitionService exhibitionService;
        private readonly MyBeetleX _cache;
        private readonly IQueuePushInfo _queue;

        public OrderController(IUserInfoService userinfoService,
            MyBeetleX _cache, 
            IHttpContextUser httpContextUser, 
            IWechatBillService billService, 
            IExhibitionService exhibitionService,
            IUserService userService,
            INamedServiceProvider<IAppointmentService> _stockProvider,
            INamedServiceProvider<IMyOrderServices> _orderProvider,
            INamedServiceProvider<IMyTicketService> _ticketProvider,
            IQueuePushInfo _queue)
        {
            this._cache = _cache;
            this.httpContextUser = httpContextUser;
            this.userinfoService = userinfoService;
            this.billService = billService;
            this.userService = userService;
            this.exhibitionService = exhibitionService;
            this._queue = _queue;

            var factory = SaaSServiceFactory.GetServiceFactory(httpContextUser.TenantId);
            this.stockService = factory.GetStockService(_stockProvider);
            this.ticketService = factory.GetTicketService(_ticketProvider);
            this.myOrderService = factory.GetOrderService(_orderProvider);
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpPost(Name = "CreateOrder")]
        public async Task<dynamic> CreateOrder([FromBody]BaseOrderCreate oc)
        {
            var userid = Guid.Parse(httpContextUser.ID);
            //var _lock = await _cache.LockNoWait("UserLock_" + userid, null, 60);
            //if (_lock == 0)
            //{
            //    return new { code = 0, message = "您的订单正在处理中,请稍后再试" };
            //}

            //去重
            oc.ids = oc.ids.Distinct().ToArray();
            if (oc.ids.Count == 0)
            {
                await _cache.ReleaseLock("UserLock_" + userid, null);
                return new { code = 0, message = "请至少选择一个人" };
            }

            var stock = await stockService.checkStock(oc.appid);
            if (stock == null)
            {
                await _cache.ReleaseLock("UserLock_" + userid, null);
                return new { code = 0, message = "库存不足" };
            }

            foreach (var item in oc.ids)
            {
                var query = await userinfoService.Exist(a => a.id == item && a.userID == userid);
                if (query == false)
                {
                    return new { code = 0, message = "所选择的用户不存在" };
                }
            }


            var left = stock.amount - stock.sale; //获取剩余票数
            var myid = await _cache.Incrby("QueueIn_" + oc.appid,oc.ids.Count);

            if (myid > left)
            {
                await _cache.Decrby("QueueIn_" + oc.appid, oc.ids.Count);
                return new { code = 0, message = "库存不足" };
            }

            ticketService.SetUserContext(userid);
            var vaild = await ticketService.Vaild(oc.ids.ToArray(), stock);
            if (vaild == false)
            {
                await _cache.Decrby("QueueIn_" + oc.appid, oc.ids.Count);
                await _cache.ReleaseLock("UserLock_" + userid, null);
                return new { status = 1,message = "用户重复" };
            }

            var exhibition = await exhibitionService.GetExhibitionByID(stock.objectId);

            var CreateOrder = new OrderCreateQueueEntity(new OrderCreate()
            {
                appid = oc.appid,
                ids = oc.ids,
                userid = userid,
                tenantId = httpContextUser.TenantId,
                price = exhibition.basicPrice,
                realTenantId = httpContextUser.RealTenantId
            });

            await _queue.PushMessage(CreateOrder);

            return new { status = 1,message = "下单请求成功，请等待下单结果" };
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PayOrder")]
        public async Task<WechatBill> PayOrder(long trade_no)
        {
            Guid lockid = Guid.NewGuid();

            await _cache.Lock("OrderLocker_" + trade_no, lockid);
            var order = await myOrderService.GetOrderById(trade_no);
            var stock = await stockService.checkStock(order.objectId);
            try
            {
                if (stock == null)
                {
                    throw new ArgumentException("支付时间已过");
                }
                if (order.status == OrderStatus.未付款)
                {
                    var bill = new WechatBill() { payTitle = "通用订票", tradeNo = order.trade_no,money = order.amount,
                        ip = "127.0.0.1",orderId = order._id};
                    var result = await billService.GenWechatBill(bill);
                    return result;
                }
                else
                {
                    throw new ArgumentException("订单已不可支付");
                }
            }
            catch (Exception e)
            {
                await myOrderService.AfterOrderToke(trade_no);
            }
            finally
            {
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid.ToString());
            }
            return null;   
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PaidOrder")]
        public async Task<dynamic> PaidOrder(long trade_no)
        {
            Guid lockid = Guid.NewGuid();
            await _cache.Lock("OrderLocker_" + trade_no, lockid);
            var order = await myOrderService.GetOrderById(trade_no);
            try
            {
                if (order.status != OrderStatus.已付款)
                {
                    await myOrderService.PayOrder(order);
                }
                return order;
            }
            catch (Exception e)
            {
                await myOrderService.AfterOrderToke(order.trade_no);
            }
            finally
            {
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid.ToString());
            }
            return null;
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "CloseOrder")]
        [UnitOfWork]
        public async Task<dynamic> CloseOrder(long trade_no)
        {
            Guid lockerId = Guid.NewGuid();
            var lo = await _cache.Lock("OrderLocker_" + trade_no, lockerId);
            var order = await myOrderService.GetOrderById(trade_no);
            if (order.status != OrderStatus.未付款)
            {
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId.ToString());
                throw new Exception("目前状态不可关闭订单");
            }

            try
            {
                var tickets = await ticketService.GetTickets(order.trade_no);
                var o = await myOrderService.CancelOrder(order);
                Appointment app = null;
                if (tickets != null)
                {
                    app = await stockService.SaleStock(order.objectId, -tickets.Count);
                }
                
                if (o == null)
                {
                    throw new Exception("订单已支付或不存在");
                }
                await ticketService.DisableTickets(tickets);

                //foreach (var ticket in tickets)
                //{
                //    var _result = await ticketService.DisableTicket(ticket);
                //}

                if (app == null)
                {
                    throw new Exception("app不能为空");
                }

                await ticketService.AfterTicketToke(order.trade_no);
            }
            catch(Exception e)
            {
                if (order != null)
                {
                    await myOrderService.AfterOrderToke(order.trade_no);
                }
                await stockService.DelStockFromCache(order.objectId);
                throw e;
            }
            finally
            {

                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId.ToString());
            }

            return null;
        }

        [Authorize]
        //[TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "Test")]
        public async Task Test()
        {
            if (httpContextUser.TenantId.Contains("5003"))
            {
                var normaluser = await userinfoService.GetWithConditionNt(a => a.id > 0);
                var adminuser = await userService.GetWithConditionNt(a => a.authLevel == 1);
                var num = normaluser.Count() / adminuser.Count();
                for (int k = 0; k < adminuser.Count; k++)
                {
                    await Task.Run(async () =>
                    {
                        int offset = new Random().Next(1, 5);
                        for (int i = k * num; i < k * num + num; i += offset)
                        {
                            Guid stockid = Guid.Parse("3DC16154-C4F5-42D6-BEEC-CC3B09D2D2D6");
                            if ((i + offset) < (k * num + num))
                            {
                                await CreateOrder(new OrderCreate() { appid = stockid, ids = normaluser.GetRange(i, offset).Select(a => a.id).ToArray() });
                            }
                        }
                    });
                    await Task.Run(async () =>
                    {
                        int offset = new Random().Next(1, 5);
                        for (int i = k * num; i < k * num + num; i += offset)
                        {
                            Guid stockid = Guid.Parse("BA050247-0548-4A05-9C60-1D8D6672A05B");
                            if ((i + offset) < (k * num + num))
                            {
                                await CreateOrder(new OrderCreate() { appid = stockid, ids = normaluser.GetRange(i, offset).Select(a => a.id).ToArray() });
                            }
                        }
                    });
                }
            }
            else
            {
                var normaluser = await userinfoService.GetWithConditionNt(a => a.id > 0);
                var adminuser = await userService.GetWithConditionNt(a => a.authLevel == 1);
                var num = normaluser.Count() / adminuser.Count();
                for (int k = 0; k < adminuser.Count; k++)
                {
                    await Task.Run(async () =>
                    {
                        int offset = new Random().Next(1, 5);
                        for (int i = k * num; i < k * num + num; i += offset)
                        {
                            Guid stockid = Guid.Parse("70FB3A70-A214-6FDD-F1F3-1A360984DA68");
                            if ((i + offset) < (k * num + num))
                            {
                                await CreateOrder(new OrderCreate() { appid = stockid, ids = normaluser.GetRange(i, offset).Select(a => a.id).ToArray() });
                            }
                        }
                    });
                    await Task.Run(async () =>
                    {
                        int offset = new Random().Next(1, 5);
                        for (int i = k * num; i < k * num + num; i += offset)
                        {
                            Guid stockid = Guid.Parse("94D175BB-4F46-4E9D-B593-32782DE5D33C");
                            if ((i + offset) < (k * num + num))
                            {
                                await CreateOrder(new OrderCreate() { appid = stockid, ids = normaluser.GetRange(i, offset).Select(a => a.id).ToArray() });
                            }
                        }
                    });
                }
            }
            
        }
    }
}
