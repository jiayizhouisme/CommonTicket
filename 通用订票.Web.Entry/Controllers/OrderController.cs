using BeetleX.Redis.Commands;
using Core.Auth;
using Core.Cache;
using Core.HttpTenant;
using Core.MiddelWares;
using Core.Queue.IQueue;
using Essensoft.Paylink.WeChatPay;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.EventBus;
using Furion.JsonSerialization;
using Furion.LinqBuilder;
using Furion.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using SqlSugar;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Transactions;
using ThoughtWorks.QRCode.Geom;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.Core.Entity.Specification;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.JobTask;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
using 通用订票.Web.Entry.Model;
using 通用订票Order.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Web.Entry.Controllers
{
    /// <summary>
    /// 订票系统
    /// </summary>
    public class OrderController : IDynamicApiController
    {
        private readonly IUserInfoService userinfoService;
        private readonly IDefaultAppointmentService stockService;
        private readonly IDefaultTicketService ticketService;
        private readonly IDefaultOrderServices myOrderService;
        private readonly IMultiTicketService multiTicketService;
        private readonly IHttpContextUser httpContextUser;
        private readonly IWechatBillService billService;
        private readonly IExhibitionService exhibitionService;
        private readonly ICacheOperation _cache;
        private readonly IQueuePushInfo _queue;
        private readonly IEventPublisher eventPublisher;
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ITenantGetSetor tenantGetSetor;
        private readonly IWechatPayService wechatPayService;
        private readonly IWechatMerchantConfigService wechatMerchantConfigService;
        private readonly IWechatRefundBillService wechatRefundBillService;
        private readonly IServiceProvider serviceProvider;
        private readonly IDevicesService devicesService;
        private readonly IAnonymousTicketService anonymousTicketService;
        public OrderController(IUserInfoService userinfoService,
            ICacheOperation _cache,
            IHttpContextUser httpContextUser,
            IWechatBillService billService,
            IExhibitionService exhibitionService,
            INamedServiceProvider<IDefaultAppointmentService> _stockProvider,
            INamedServiceProvider<IDefaultOrderServices> _orderProvider,
            INamedServiceProvider<IDefaultTicketService> _ticketProvider,
            IQueuePushInfo _queue,
            IEventPublisher eventPublisher,
            IJsonSerializerProvider jsonSerializerProvider,
            ITenantGetSetor tenantGetSetor,
            IWechatPayService wechatPayService,
            IWechatMerchantConfigService wechatMerchantConfigService,
            IWechatRefundBillService wechatRefundBillService,
            IServiceProvider serviceProvider,
            IMultiTicketService multiTicketService,
            IDevicesService devicesService,
            IAnonymousTicketService anonymousTicketService)
        {
            this._cache = _cache;
            this.httpContextUser = httpContextUser;
            this.userinfoService = userinfoService;
            this.billService = billService;
            this.exhibitionService = exhibitionService;
            this._queue = _queue;
            this.eventPublisher = eventPublisher;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this.tenantGetSetor = tenantGetSetor;
            this.wechatMerchantConfigService = wechatMerchantConfigService;
            this.wechatRefundBillService = wechatRefundBillService;

            var factory = SaaSServiceFactory.GetServiceFactory(httpContextUser.TenantId);
            this.stockService = factory.GetStockService(_stockProvider);
            this.ticketService = factory.GetTicketService(_ticketProvider);
            this.myOrderService = factory.GetOrderService(_orderProvider);
            this.wechatPayService = wechatPayService;
            this.serviceProvider = serviceProvider;
            this.multiTicketService = multiTicketService;
            this.devicesService = devicesService;
            this.anonymousTicketService = anonymousTicketService;
        }

        [NonUnify]
        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.LocalStaff } })]
        [Route("CreateAnonymousTicket")]
        public async Task<CreateAnonymousReturn> CreateAnonymousTicket(AddAnonymousTicket ticket)
        {
            var userid = long.Parse(httpContextUser.ID);
            var ex = await exhibitionService.GetExhibitionByID(ticket.exhibitionId);
            Ticket result = null;
            userinfoService.SetUserContext(userid);
            var user = (await userinfoService.GetWithConditionNt(a => a.idCard == ticket.idcard && a.isAnonymous == true && a.userID == userid)).FirstOrDefault();
            if (user == null)
            {
                user = await userinfoService.Add(new UserInfo
                {
                    idCard = ticket.idcard,
                    name = ticket.username,
                    phoneNumber = ticket.phoneNumber,
                    isAnonymous = true
                });
            }
            else
            {
                await userinfoService.Update(new UserInfo
                {
                    id = user.id,
                    idCard = ticket.idcard,
                    name = ticket.username,
                    phoneNumber = ticket.phoneNumber,
                    isAnonymous = true
                }) ;
            }
            if (ex.isMultiPart)
            {
                var exids = ex.exhibitions.Split(',').ToArray();
                result = await anonymousTicketService.GenarateAnonymousTickets(ticket.exhibitionId, DateTime.Now, DateTime.Now.AddHours(24), user.id,  ticket.totalCount,exids);
            }
            else
            {
                result = await anonymousTicketService.GenarateAnonymousTickets(ticket.exhibitionId, DateTime.Now, DateTime.Now.AddHours(24), user.id,ticket.totalCount);
            }

            return new CreateAnonymousReturn() {amount = ticket.amount,exhibitionName = ex.name,
                ticketNumber = result.ticketNumber,username = ticket.username,qrcode = result.QRCode,
                createTime = result.createTime,startTime = result.startTime,endTime = result.endTime
                
            };
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="oc">订单信息</param>
        /// <returns></returns>
        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [EnableRateLimiting("order_create_rate_policy")]
        [HttpPost(Name = "CreateOrder")]
        public async Task<object> CreateOrder([FromBody] BaseOrderCreate oc)
        {
            var userid = long.Parse(httpContextUser.ID);

            myOrderService.SetUserContext(userid);
            userinfoService.SetUserContext(userid);

            var _lock = await myOrderService.PreOrder(oc.appid);
            if (_lock == false)
            {
                return new { status = 0, message = "您的订单正在处理中,请稍后再试" };
            }

            UserOrdersCollectionSpecification us = new UserOrdersCollectionSpecification(userid, oc.appid);
            var orderCount = myOrderService.GetQueryableNt(us.ToExpression()).Select(a => a.userId);
            if (await orderCount.CountAsync() >= 15)
            {
                await myOrderService.OrderFail(oc.appid);
                return new { status = 0, message = "购票数量达到上线" };
            }

            oc.ids = oc.ids.Distinct().ToArray();
            foreach (var item in oc.ids)
            {
                UserInfoOwnByUserExistSpecification uis = new UserInfoOwnByUserExistSpecification(item, userid);
                var query = await userinfoService.Exist(uis.ToExpression());
                if (query == false)
                {
                    await myOrderService.OrderFail(oc.appid);
                    return new { status = 0, message = "所选择的用户不存在" };
                }
            }

            var saleRet = await stockService.SaleStock(oc.appid, oc.ids.Count);
            if (saleRet == false)
            {
                await myOrderService.OrderFail(oc.appid);
                return new { status = 1, message = "库存不足" };
            }

            var stock = await stockService.checkStock(oc.appid);
            try
            {
                var exhibition = await exhibitionService.GetExhibitionByID(stock.objectId);
                var rule = exhibition.GetForbiddenRule();

                if (rule != null && rule.IsDateVaild(DateTime.Now.AddDays(stock.day)) == false)
                {
                    throw new Exception("选择的日期不可用");
                }

                if (stock.day - exhibition.beforeDays < 0)
                {
                    throw new Exception("选择日期不正确");
                }

                string extraInfo = jsonSerializerProvider.Serialize(new OrderInfo { appid = oc.appid, ids = oc.ids.ToArray() });

                var order = await myOrderService.CreateOrder(
                    stock.id,
                    exhibition.name,
                    exhibition.id,
                    stock.day,
                    exhibition.basicPrice * oc.ids.Count,
                    oc.ids.Count,
                    extraInfo);

                await myOrderService.AfterOrdered(oc.appid);

                var CreateOrder = new OrderCreateQueueEntity(new OrderCreate()
                {
                    order = order,
                    appid = oc.appid,
                    ids = oc.ids,
                    userid = userid,
                    tenantId = httpContextUser.TenantId,
                    price = exhibition.basicPrice
                });
                await _queue.PushMessage(CreateOrder);

                return new { status = 1, message = "下单请求成功，请等待下单结果", data = new { exhibition.name, isFree = order.amount == 0 ? true : false, order.trade_no } };
            }
            catch (Exception e)
            {
                await myOrderService.OrderFail(oc.appid);
                await stockService.SaleStock(stock.id, -oc.ids.Count);
                return new
                {
                    status = 0,
                    message = e.Message
                };
                throw e;
            }
        }

        /// <summary>
        /// 支付订单
        /// </summary>
        /// <param name="trade_no">订单编号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Authorize]
        [NonUnify]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PayOrder")]
        public async Task<WeChatPayDictionary> PayOrder([FromQuery] long trade_no)
        {
            string lockid = Guid.NewGuid().ToString();

            await _cache.Lock("OrderLocker_" + trade_no, lockid);

            var order = await myOrderService.GetOrderById(trade_no);
            try
            {
                if (order == null || order.userId.ToString() != httpContextUser.ID)
                {
                    throw new ArgumentException("订单无效");
                }
                WeChatPayDictionary wc = null;
                if (order.status == OrderStatus.未付款)
                {
                    var Attach = new WechatBillAttach
                    {
                        tenant_id = httpContextUser.TenantId,
                        trade_no = trade_no
                    };

                    var result = await billService.GenWechatBill(order, Attach, long.Parse(httpContextUser.ID));
                    if (result == null || string.IsNullOrEmpty(result.parameters))
                    {
                        var config = await wechatMerchantConfigService.GetConfig();
                        var openid = httpContextUser.OpenId;
                        if (config != null && !string.IsNullOrEmpty(openid))
                        {
                            wc = await wechatPayService.PubPay(result, config, openid);
                            if (wc != null && !string.IsNullOrEmpty(result.parameters))
                            {
                                await billService.UpdateNow(result);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("参数错误");
                        }
                        return wc;
                    }
                    else
                    {
                        wc = JSON.Deserialize<WeChatPayDictionary>(result.parameters);
                        return wc;
                    }
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

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="trade_no">订单编号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "RefundOrder")]
        [NonUnify]
        public async Task<dynamic> RefundOrder([FromQuery] long trade_no)
        {
            string lockid = Guid.NewGuid().ToString();

            await _cache.Lock("OrderLocker_" + trade_no, lockid);

            var order = await myOrderService.GetOrderById(trade_no);
            DbContext dbContext = Db.GetDbContext(serviceProvider);
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (order == null || order.userId.ToString() != httpContextUser.ID)
                    {
                        throw new ArgumentException("订单无效");
                    }

                    if (order.status == OrderStatus.已付款 && order.ticketStatus != TicketStatus.部分使用 
                        && order.ticketStatus != TicketStatus.已使用)
                    {
                        WechatBill bill = null;
                        WechatBillRefund billRefund = null;
                        if (order.amount > 0)
                        {
                            bill = await billService.GetWechatBill(order.trade_no);
                            if (bill == null)
                            {
                                throw new Exception("退款失败，未找到微信订单");
                            }
                            billRefund = await wechatRefundBillService.GenWechatRefundBill(bill);
                            if (billRefund == null)
                            {
                                throw new Exception("退款失败，因为已经退款成功或者退款正在进行");
                            }
                        }

                        await myOrderService.PreRefundOrder(order);
                        var onOrderPreRefuned = new OnOrderPreRefunded()
                        {
                            order = order,
                            billRefund = billRefund,
                            tenantId = httpContextUser.TenantId,
                            userId = long.Parse(httpContextUser.ID),
                            bill = bill
                        };
                        await transaction.CommitAsync();
                        await eventPublisher.PublishAsync(new OnOrderPreRefundedEvent(onOrderPreRefuned));
                        return new { code = 1, message = "订单退款请求成功，请耐心等待退款", amount = order.amount, time = DateTime.Now, trade_no };
                    }
                    else
                    {
                        throw new ArgumentException("订单已不可退款");
                    }
                }
                catch (Exception e)
                {
                    await myOrderService.AfterOrderToke(trade_no);
                    Log.Error(e.Message);
                    return new { code = 0, message = e.Message };
                }
                finally
                {
                    await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid);
                }
            }

        }

        /// <summary>
        /// 通知后台订单已支付
        /// </summary>
        /// <param name="trade_no">订单编号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PaidOrder")]
        [NonUnify]
        public async Task<通用订票.Core.Entity.Order> PaidOrder([FromQuery] long trade_no)
        {
            string lockid = Guid.NewGuid().ToString();

            await _cache.Lock("OrderLocker_" + trade_no, lockid);
            var order = await myOrderService.GetOrderById(trade_no);
            try
            {
                if (order == null || order.userId.ToString() != httpContextUser.ID)
                {
                    throw new ArgumentException("订单已不可支付");
                }

                if (order.status == OrderStatus.已关闭 || order.status == OrderStatus.未付款)
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
            return order;
        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="trade_no">订单编号</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "CloseOrder")]
        [NonUnify]
        public async Task<dynamic> CloseOrder([FromQuery] long trade_no)
        {
            string lockerId = Guid.NewGuid().ToString();
            await _cache.Lock("OrderLocker_" + trade_no, lockerId);
            var order = await myOrderService.GetOrderById(trade_no);
            try
            {
                if (order == null || order.userId.ToString() != httpContextUser.ID)
                {
                    throw new ArgumentException("目前状态不可关闭订单");
                }

                if (order.status != OrderStatus.未付款)
                {
                    throw new Exception("目前状态不可关闭订单");
                }
                var o = await myOrderService.CancelOrder(order);

                var onOrderClosed = new OnOrderClosed()
                {
                    order = order,
                    tenantId = httpContextUser.TenantId,
                    userId = long.Parse(httpContextUser.ID
                    ) };
                await eventPublisher.PublishAsync(new OnOrderClosedEvent(onOrderClosed));
            }
            catch (Exception e)
            {
                throw e;
                return new { code = 0, message = e.Message };
            }
            finally
            {

                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId);
            }

            return new { code = 1, message = "关闭订单成功" };
        }

        /// <summary>
        /// 验票
        /// </summary>
        /// <param name="ticket_number">票号</param>
        /// <param name="count">核销数量</param>
        /// <param name="exhibition">景区id</param>
        /// <returns></returns>
        [HttpGet(Name = "CheckTicket")]
        [NonUnify]
        public async Task<TicketVerifyResult> CheckTicket([FromQuery] string ticket_number, [FromQuery] int count = 1, [FromQuery] string exhibition = null)
        {
            var ticket = await ticketService.TicketBeginCheck(ticket_number, count, exhibition);
            if (ticket.ticket != null)
            {
                ticket.order = await myOrderService.GetOrderById(ticket.ticket.objectId);
            }

            if (ticket.order.status != OrderStatus.已付款)
            {
                ticket.code = 0;
                ticket.message = "订单已不可用";
                await ticketService.TicketEndCheck(ticket.ticket);
            }

            await ticketService.TicketEndCheck(ticket.ticket);

            return ticket;
        }
        /// <summary>
        /// 消票
        /// </summary>
        /// <param name="ticket_number">票号</param>
        /// <param name="count">核销数量</param>
        /// <param name="exhibition">景区id</param>
        /// <returns></returns>
        [HttpGet(Name = "UseTicket")]
        [NonUnify]
        public async Task UseTicket([FromQuery] string ticket_number, [FromQuery] int count = 1, [FromQuery] string exhibition = null)
        {
            var ticket = await ticketService.GetTicket(ticket_number);
            await eventPublisher.PublishAsync("TicketVerifyEvent", new TicketVerifyEventModel
            {
                type = ticket.ota,
                ticketNumber = ticket_number,
                count = count,
                tenant_id = tenantGetSetor.Get(),
                exhibitionId = exhibition,
                status = ticket.stauts
            });
        }

        /// <summary>
        /// 验票并消票
        /// </summary>
        /// <param name="ticket_number">票号</param>
        /// <param name="count">核销数量</param>
        /// <param name="exhibition">景区id</param>
        /// <returns></returns>
        [HttpGet(Name = "CheckTicketAndUse")]
        [NonUnify]
        public async Task<TicketVerifyResult> CheckTicketAndUse([FromQuery] string ticket_number, [FromQuery] int count = 1, [FromQuery] string exhibition = null)
        {
            var ticket = await ticketService.TicketBeginCheck(ticket_number, count, exhibition);
            

            if (ticket.code == 0)
            {
                ticket.code = 0;
                await ticketService.TicketEndCheck(ticket.ticket);
                return ticket;
            }

            if (ticket.ticket.isAnonymous == false)
            {
                if (ticket.ticket != null)
                {
                    ticket.order = await myOrderService.GetOrderById(ticket.ticket.objectId);
                }

                if (ticket.order == null || ticket.order.status != OrderStatus.已付款)
                {
                    ticket.code = 0;
                    ticket.message = "订单已不可用";
                    await ticketService.TicketEndCheck(ticket.ticket);
                    return ticket;
                }
            }

            if (ticket.code == 1)
            {
                //ticket.app = await stockService.GetAppointmentById(ticket.ticket.AppointmentId);
                //ticket.exhibition = await exhibitionService.GetExhibitionByID(ticket.app.objectId);
                await eventPublisher.PublishAsync("TicketVerifyEvent", new TicketVerifyEventModel
                {
                    type = ticket.ticket.ota,
                    ticketNumber = ticket_number,
                    count = count,
                    tenant_id = tenantGetSetor.Get(),
                    exhibitionId = exhibition,
                    status = ticket.ticket.stauts
                });
            }
            else
            {
                await ticketService.TicketEndCheck(ticket.ticket);
            }
            return ticket;
        }

        [HttpGet(Name = "GetOrdersByStatus")]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [NonUnify]
        public async Task<List<UserOrderQueryModel>> GetOrdersByStatus([FromQuery] UserOrderQueryEnum status = UserOrderQueryEnum.全部)
        {
            var userId = long.Parse(httpContextUser.ID);
            var orderList = this.myOrderService.GetQueryableNt(a => a.userId == userId).OrderByDescending(a => a.createTime).AsQueryable();
            if (status == UserOrderQueryEnum.全部)
            {
                return await orderList.Select(a =>
                new UserOrderQueryModel(a))
                .ToListAsync(); ;
            } else if (status == UserOrderQueryEnum.待付款)
            {
                orderList = orderList.Where(a => a.status == OrderStatus.未付款);
            }
            else if (status == UserOrderQueryEnum.未使用)
            {
                orderList = orderList.Where(a => a.status == OrderStatus.已付款 && a.ticketStatus == TicketStatus.未使用);
            }
            else if (status == UserOrderQueryEnum.已使用)
            {
                orderList = orderList.Where(a => a.status == OrderStatus.已付款 && (a.ticketStatus == TicketStatus.已使用 || a.ticketStatus == TicketStatus.部分使用));
            }
            else if (status == UserOrderQueryEnum.已退款)
            {
                orderList = orderList.Where(a => a.status == OrderStatus.已退款);
            }

            return await orderList.Select(a =>
                new UserOrderQueryModel(a)).ToListAsync();
        }
        
        [HttpGet(Name = "GetOrderDetail")]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [NonUnify]
        public async Task<UserOrderDetailQueryModel> GetOrderDetail([FromQuery] long trade_no)
        {
            var order = await myOrderService.GetOrderById(trade_no);
            var tickets = await ticketService.GetTickets(order.trade_no);
            UserOrderDetailQueryModel model = new UserOrderDetailQueryModel(order);
            model.tickets = new List<TicketQueryModel>();
            foreach (var ticket in tickets)
            {
                var username = (await userinfoService.GetUserInfoByID(ticket.TUserId)).name;

                if (ticket.isMultiPart)
                {
                    var list = await multiTicketService.GetQueryableNt(a => a.ticketNumber == ticket.ticketNumber).
                        Select(a => new MultiTicketQueryModel(a)).ToListAsync();
                    foreach (var mt in list)
                    {
                        mt.exhibitionName = (await exhibitionService.GetExhibitionByID(mt.exhibitionId)).name;
                    }
                    model.tickets.Add(
                        new TicketQueryModel()
                        {
                            name = username,
                            startTime = ticket.startTime,
                            qrCode = ticket.QRCode,
                            ticketNumber = ticket.ticketNumber,
                            totalCount = ticket.totalCount - ticket.usedCount,
                            mtickets = list
                        }
                    );
                }
                else
                {
                    model.tickets.Add(
                    new TicketQueryModel()
                    {
                        name = username,
                        startTime = ticket.startTime,
                        ticketNumber = ticket.ticketNumber,
                        qrCode = ticket.QRCode,
                        totalCount = ticket.totalCount - ticket.usedCount,
                        mtickets = new List<MultiTicketQueryModel>()
                    }
                );
                }
            }
            return model;
        }

        [HttpGet(Name = "GetOrders")]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [NonUnify]
        public async Task<List<GetOrdersModel>> GetOrders(
            [FromQuery] UserOrderQueryEnum status,
            [FromQuery] string exhibitionId = null,
            [FromQuery] string date = null,
            [FromQuery] int pageIndex = 1, 
            [FromQuery] int pageSize = 10)
        {
            var order_query = myOrderService.GetQueryableNt(a => a != null)
                .OrderByDescending(a => a.createTime).AsQueryable();
            if (!string.IsNullOrEmpty(exhibitionId))
            {
                Guid id;
                Guid.TryParse(exhibitionId,out id);

                order_query = order_query.Where(a => a.exhibitionId == id);
            }

            if (status == UserOrderQueryEnum.待付款)
            {
                order_query = order_query.Where(a => a.status == OrderStatus.未付款);
            }else if (status == UserOrderQueryEnum.已退款)
            {
                order_query = order_query.Where(a => a.status == OrderStatus.已退款);
            }
            else if (status == UserOrderQueryEnum.待付款)
            {
                order_query = order_query.Where(a => a.status == OrderStatus.未付款);
            }
            else if (status == UserOrderQueryEnum.未使用)
            {
                order_query = order_query.Where(a => a.ticketStatus == TicketStatus.未使用 && a.status == OrderStatus.已付款);
            }
            else if (status == UserOrderQueryEnum.已使用)
            {
                order_query = order_query.Where(a => (a.ticketStatus == TicketStatus.未使用 || a.ticketStatus == TicketStatus.部分使用) 
                && a.status == OrderStatus.已付款);
            }
            
            if (date != null)
            {
                DateTime now;
                DateTime.TryParse(date,out now);

                order_query = order_query.Where(a => a.createTime.Value.Date.CompareTo(now) == 0);
            }
            var orders = await order_query.Select(a => new GetOrdersModel(a)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return orders;
        }

        [HttpGet(Name = "GetTicketsDetail")]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [NonUnify]
        public async Task<PagedList<GetTicketsModel>> GetTicketsDetail(
            [FromQuery] UserOrderQueryEnum status,
            [FromQuery] string exhibitionId = null,
            [FromQuery] string date = null,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var ticket_query = ticketService.GetQueryableNt(a => a != null)
                .OrderByDescending(a => a.createTime).AsQueryable();
            if (!string.IsNullOrEmpty(exhibitionId))
            {
                Guid id;
                Guid.TryParse(exhibitionId, out id);

                ticket_query = ticket_query.Where(a => a.exhibitionId == id);
            }

            if (status == UserOrderQueryEnum.未使用)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.未使用);
            }
            else if (status == UserOrderQueryEnum.已使用)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.已使用);
            }
            else if (status == UserOrderQueryEnum.已冻结)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.已冻结);
            }

            if (date != null)
            {
                DateTime now;
                DateTime.TryParse(date, out now);

                ticket_query = ticket_query.Where(a => a.startTime.Date.CompareTo(now) == 0);
            }
            var _paged_tickets = await ticket_query.ToPagedListAsync(pageIndex, pageSize);
            var tickets = _paged_tickets.Items.ToArray();
            
            List<GetTicketsModel> list = new List<GetTicketsModel>();
            for (int i = 0; i < tickets.Length; i++)
            {
                var order = await myOrderService.GetOrderById(tickets[i].objectId);
                var exhibition = await exhibitionService.GetExhibitionByID(order.exhibitionId);
                var app = await stockService.GetAppointmentById(order.objectId);
                var userinfo = await userinfoService.GetUserInfoByID(tickets[i].TUserId);
                GetTicketsModel gtm = new GetTicketsModel(order, tickets[i],exhibition,app,userinfo);
                list.Add(gtm);
            }
            PagedList<GetTicketsModel> pl = new PagedList<GetTicketsModel>();
            pl.TotalCount = _paged_tickets.TotalCount;
            pl.TotalPages = _paged_tickets.TotalPages;
            pl.HasNextPages = _paged_tickets.HasNextPages;
            pl.HasPrevPages = _paged_tickets.HasPrevPages;
            pl.PageIndex = _paged_tickets.PageIndex;
            pl.PageSize = _paged_tickets.PageSize;
            pl.Items = list;
            return pl;

        }

        [HttpGet(Name = "GetTickets")]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [NonUnify]
        public async Task<PagedList<GetTicketsModel>> GetTickets(
            [FromQuery] UserOrderQueryEnum status,
            [FromQuery] string exhibitionId = null,
            [FromQuery] string date = null,
            [FromQuery] string username = null,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {

            var ticket_query = _GetTickets(exhibitionId, status, date, pageIndex, pageSize).Include(a => a.userinfo).AsQueryable();
            if (!string.IsNullOrEmpty(username))
            {
                ticket_query = ticket_query.Where(a => a.userinfo != null && a.userinfo.name == username);
            }
            var totalcount = await ticket_query.CountAsync();
            var tickets = await ticket_query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArrayAsync();
            List<GetTicketsModel> list = new List<GetTicketsModel>();
            for (int i = 0; i < tickets.Length; i++)
            {
                var order = await myOrderService.GetOrderById(tickets[i].objectId);
                if (order == null)
                {
                    continue;
                }
                var exhibition = await exhibitionService.GetExhibitionByID(order.exhibitionId);
                var app = await stockService.GetAppointmentById(order.objectId);
                if (app == null)
                {
                    continue;
                }
                GetTicketsModel gtm = new GetTicketsModel(order, tickets[i], exhibition, app, tickets[i].userinfo);
                list.Add(gtm);
            }
            PagedList<GetTicketsModel> pl = new PagedList<GetTicketsModel>();
            pl.TotalCount = totalcount;
            pl.TotalPages = totalcount / pageSize + 1;
            pl.PageIndex = pageIndex;
            pl.PageSize = pageSize;
            pl.PageSize = pageSize;
            pl.Items = list;
            return pl;

        }

        private IQueryable<Ticket> _GetTickets(string exhibitionId,UserOrderQueryEnum status,string date, int pageIndex,int pageSize)
        {
            var ticket_query = ticketService.GetQueryableNt(a => a.isAnonymous == false)
                .OrderByDescending(a => a.createTime).AsQueryable();
            if (!string.IsNullOrEmpty(exhibitionId))
            {
                Guid id;
                Guid.TryParse(exhibitionId, out id);

                ticket_query = ticket_query.Where(a => a.exhibitionId == id);
            }

            if (status == UserOrderQueryEnum.未使用)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.未使用);
            }
            else if (status == UserOrderQueryEnum.已使用)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.已使用 || a.stauts == TicketStatus.部分使用);
            }
            else if (status == UserOrderQueryEnum.已冻结 || status == UserOrderQueryEnum.已退款)
            {
                ticket_query = ticket_query.Where(a => a.stauts == TicketStatus.已冻结);
            }

            if (!string.IsNullOrEmpty(date))
            {
                DateTime now;
                DateTime.TryParse(date, out now);

                ticket_query = ticket_query.Where(a => a.startTime.Date.CompareTo(now) == 0);
            }
            return ticket_query;
        }

        [NonUnify]
        [HttpPost(Name = "MachineCheck")]
        public async Task<FaceDeviceVerifyResultReturn> MachineCheck([FromBody] FaceDeviceCallbackModel body)
        {
            int cmd = 1;
            int code = 1;
            string message = "验票成功";
            var exid = (await devicesService.GetDeviceBySn(body.deviceSn)).FirstOrDefault();

            if (exid == null)
            {
                return new FaceDeviceVerifyResultReturn()
                {
                    cmd = -1,
                    code = -1,
                    message = "验证失败",
                    voiceData = "验证失败"
                };
            }

            if (exid.type == DeviceType.inDevice)
            {
                if (body.type == 2)
                {
                    var ticket_number = body.data.Split('=')[1];
                    var result = await CheckTicketAndUse(ticket_number, 1, exid.exhibitionId);
                    if (result.code == 0)
                    {
                        cmd = -1;
                        code = -1;
                        message = "验票失败";
                    }
                    var _r = new FaceDeviceVerifyResultReturn()
                    {
                        cmd = cmd,
                        code = code,
                        message = message,
                        voiceData = message
                    };
                    if (result.code == 1)
                    {
                        await eventPublisher.PublishAsync(new OnMachineTicketVerifiedEvent(new OnMachineTicketVerified
                        {
                            tenantId = tenantGetSetor.Get(),
                            Device = exid,
                            userinfo_id = result.ticket.TUserId,
                            updateTime = DateTime.Now
                        }));
                    }
                    
                    return _r;
                }

                var userinfo = await (userinfoService.GetQueryableNt(a => a.idCard == body.data).Select(a => a.id).FirstOrDefaultAsync());
                if (userinfo == null)
                {
                    return new FaceDeviceVerifyResultReturn()
                    {
                        cmd = -1,
                        code = -1,
                        message = "用户不存在",
                        voiceData = "未找到游客信息"
                    };
                }

                var userticket = await ticketService.GetQueryableNt(
                    a => a.TUserId == userinfo &&
                    (a.stauts == TicketStatus.部分使用 ||
                    a.stauts == TicketStatus.未使用)
                ).OrderByDescending(a => a.createTime).FirstOrDefaultAsync();


                if (userticket == null || string.IsNullOrEmpty(exid.exhibitionId))
                {
                    return new FaceDeviceVerifyResultReturn()
                    {
                        cmd = -1,
                        code = -1,
                        message = "验票失败",
                        voiceData = "验票失败"
                    };
                }
                else
                {
                    var result = await CheckTicketAndUse(userticket.ticketNumber, 1, exid.exhibitionId);
                    if (result.code == 0)
                    {
                        code = -1;
                        cmd = -1;
                        message = "验票失败";
                    }

                    if (result.code == 1)
                    {
                        await eventPublisher.PublishAsync(new OnMachineTicketVerifiedEvent(new OnMachineTicketVerified
                        {
                            tenantId = tenantGetSetor.Get(),
                            Device = exid,
                            userinfo_id = userinfo,
                            updateTime = DateTime.Now,
                            
                        }));
                    }

                    return new FaceDeviceVerifyResultReturn()
                    {
                        cmd = code,
                        code = cmd,
                        message = message,
                        voiceData = message
                    };
                }
            }else if (exid.type == DeviceType.outDevice)
            {
                long userinfo_id = 0;
                if (body.type == 2)
                {
                    var ticket_number = body.data.Split('=')[1];
                    var ticket = await ticketService.GetTicket(ticket_number);
                    userinfo_id = ticket.TUserId;
                }
                else
                {
                    userinfo_id = await userinfoService.GetQueryableNt(a => a.idCard == body.data).Select(a => a.id).FirstOrDefaultAsync();
                }
                if (userinfo_id != 0)
                {
                    await eventPublisher.PublishAsync(new OnMachineTicketVerifiedEvent(new OnMachineTicketVerified
                    {
                        tenantId = tenantGetSetor.Get(),
                        Device = exid,
                        userinfo_id = userinfo_id,
                        updateTime = DateTime.Now
                    }));
                }
                
                return new FaceDeviceVerifyResultReturn()
                {
                    cmd = 1,
                    code = 1,
                    message = "",
                    voiceData = ""
                };
            }

            return null;

            
        }

        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.LocalStaff } })]
        [HttpGet(Name = "GetAnonymousTickets")]
        public async Task<PagedList<GetAnonymousTicketReturn>> GetAnonymousTickets([FromQuery] int pageIndex = 1, [FromQuery]  int pageSize = 10)
        {
            var userid = long.Parse(httpContextUser.ID);
            List<GetAnonymousTicketReturn> list = new List<GetAnonymousTicketReturn>();
            var ts = await ticketService.GetQueryableNt(a => a.isAnonymous == true).OrderByDescending(a => a.createTime).ToPagedListAsync(pageIndex, pageSize);
            foreach (var item in ts.Items)
            {
                var userinfo = (await userinfoService.GetWithConditionNt(a => a.id == item.TUserId && a.isAnonymous == true && a.userID == userid)).FirstOrDefault();
                if (userinfo == null)
                {
                    continue;
                }
                list.Add(new GetAnonymousTicketReturn() {
                    createTime = item.createTime,
                    exhibitionId = item.exhibitionId,
                    qrcode = item.QRCode,
                    ticketNumber = item.ticketNumber,
                    totalCount = item.totalCount,
                    usedCount = item.usedCount,
                    startTime = item.startTime,
                    endTime = item.endTime,
                    phoneNumber = userinfo.phoneNumber,
                    idCard = userinfo.idCard,
                    name = userinfo.name
                });
            }

            return new PagedList<GetAnonymousTicketReturn>()
            {
                HasNextPages = ts.HasNextPages,
                HasPrevPages = ts.HasPrevPages,
                Items = list,
                PageIndex = ts.PageIndex,
                PageSize = ts.PageSize,
                TotalCount = ts.TotalCount,
                TotalPages = ts.TotalPages
            };
        }

        [NonUnify]
        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.LocalStaff } })]
        [HttpGet(Name = "GetTicketByTicketNumber")]
        public async Task<List<GetAnonymousTicketReturn>> GetTicketByTicketNumber([FromQuery] string ticketNumber,[FromQuery] bool isAnonymous = false)
        {
            var userid = long.Parse(httpContextUser.ID);
            List<GetAnonymousTicketReturn> list = new List<GetAnonymousTicketReturn>();

            var _tn = long.Parse(ticketNumber);
            var order = await myOrderService.GetOrderById(_tn);
            if (order == null)
            {
                return new List<GetAnonymousTicketReturn>();
            }
            var ts = await ticketService.GetQueryableNt(a => a.isAnonymous == isAnonymous && a.objectId == _tn).ToListAsync();
            foreach (var item in ts)
            {
                var userinfo = (await userinfoService.GetWithConditionNt(a => a.id == item.TUserId && a.isAnonymous == isAnonymous)).FirstOrDefault();
                if (userinfo == null)
                {
                    continue;
                }
                list.Add(new GetAnonymousTicketReturn()
                {
                    createTime = item.createTime,
                    exhibitionId = item.exhibitionId,
                    qrcode = item.QRCode,
                    ticketNumber = item.ticketNumber,
                    totalCount = item.totalCount,
                    usedCount = item.usedCount,
                    startTime = item.startTime,
                    endTime = item.endTime,
                    phoneNumber = userinfo.phoneNumber,
                    idCard = userinfo.idCard,
                    name = userinfo.name
                });
            }

            return list;
        }
    }
}
