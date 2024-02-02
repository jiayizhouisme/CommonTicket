using Core.Auth;
using Core.Cache;
using Core.MiddelWares;
using Core.Queue.IQueue;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.RedisMQ.Entity;
using 通用订票Order.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    public class OrderController : IDynamicApiController
    {
        private readonly IUserInfoService userinfoService;
        private readonly IUserService userService;
        private readonly IDefaultAppointmentService stockService;
        private readonly IDefaultTicketService ticketService;
        private readonly IDefaultOrderServices myOrderService;
        private readonly IHttpContextUser httpContextUser;
        private readonly IWechatBillService billService;
        private readonly IExhibitionService exhibitionService;
        private readonly ICacheOperation _cache;
        private readonly IQueuePushInfo _queue;

        public OrderController(IUserInfoService userinfoService,
            ICacheOperation _cache, 
            IHttpContextUser httpContextUser, 
            IWechatBillService billService, 
            IExhibitionService exhibitionService,
            IUserService userService,
            INamedServiceProvider<IDefaultAppointmentService> _stockProvider,
            INamedServiceProvider<IDefaultOrderServices> _orderProvider,
            INamedServiceProvider<IDefaultTicketService> _ticketProvider,
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
            string lockierid = userid.ToString();

            //var _lock = await _cache.LockNoWait("UserLock_" + userid, lockierid, 60);
            //if (_lock == 0)
            //{
            //    return new { code = 0, message = "您的订单正在处理中,请稍后再试" };
            //}

            //去重
            oc.ids = oc.ids.Distinct().ToArray();
           

            var stock = await stockService.checkStock(oc.appid);
            if (stock == null)
            {
                await _cache.ReleaseLock("UserLock_" + userid, lockierid);
                return new { code = 0, message = "库存不足" };
            }

            foreach (var item in oc.ids)
            {
                var query = await userinfoService.Exist(a => a.id == item && a.userID == userid);
                if (query == false)
                {
                    await _cache.ReleaseLock("UserLock_" + userid, lockierid);
                    return new { code = 0, message = "所选择的用户不存在" };
                }
            }

            var left = stock.amount - stock.sale; //获取剩余票数
            var myid = await _cache.Incrby("QueueIn_" + oc.appid,oc.ids.Count);

            if (myid > left)
            {
                await _cache.Decrby("QueueIn_" + oc.appid, oc.ids.Count);
                await _cache.ReleaseLock("UserLock_" + userid, lockierid);
                return new { code = 0, message = "库存不足" };
            }

            ticketService.SetUserContext(userid);
            var vaild = await ticketService.Vaild(oc.ids.ToArray(), stock);
            if (vaild == false)
            {
                await _cache.Decrby("QueueIn_" + oc.appid, oc.ids.Count);
                await _cache.ReleaseLock("UserLock_" + userid, lockierid);
                return new { status = 1,message = "用户重复" };
            }

            var exhibition = await exhibitionService.GetExhibitionByID(stock.objectId);

            var CreateOrder = new OrderCreateQueueEntity(new OrderCreate()
            {
                appid = oc.appid,
                ids = oc.ids,
                userid = userid,
                tenantId = httpContextUser.TenantId,
                price = exhibition.basicPrice
            });

            await _queue.PushMessage(CreateOrder);

            return new { status = 1,message = "下单请求成功，请等待下单结果" };
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PayOrder")]
        public async Task<WechatBill> PayOrder(long trade_no)
        {
            string lockid = Guid.NewGuid().ToString();

            await _cache.Lock("OrderLocker_" + trade_no, lockid);
            var order = await myOrderService.GetOrderById(trade_no);

            if (order == null || order.userId.ToString() != httpContextUser.ID)
            {
                throw new ArgumentException("订单已不可支付");
            }

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
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid);
            }
            return null;   
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PaidOrder")]
        public async Task<dynamic> PaidOrder(long trade_no)
        {
            string lockid = Guid.NewGuid().ToString();
            await _cache.Lock("OrderLocker_" + trade_no, lockid);
            var order = await myOrderService.GetOrderById(trade_no);

            if (order == null || order.userId.ToString() != httpContextUser.ID)
            {
                throw new ArgumentException("订单已不可支付");
            }

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
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid);
            }
            return null;
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "CloseOrder")]
        [UnitOfWork]
        public async Task<dynamic> CloseOrder(long trade_no)
        {
            string lockerId = Guid.NewGuid().ToString();
            var lo = await _cache.Lock("OrderLocker_" + trade_no, lockerId);
            var order = await myOrderService.GetOrderById(trade_no);
            if (order == null || order.userId.ToString() != httpContextUser.ID)
            {
                throw new ArgumentException("目前状态不可关闭订单");
            }

            if (order.status != OrderStatus.未付款)
            {
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId);
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

                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId);
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
                            Guid stockid = Guid.Parse("8A181236-9ACF-4442-B8DF-46649D7C5953");
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
                            Guid stockid = Guid.Parse("B53BBFAD-A7A5-49C4-A0DD-BB0849501A45");
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
