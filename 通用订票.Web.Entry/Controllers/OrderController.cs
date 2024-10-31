using Core.Auth;
using Core.Cache;
using Core.HttpTenant;
using Core.MiddelWares;
using Core.Queue.IQueue;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Meta;
using SqlSugar;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Transactions;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;
using 通用订票.Core.Entity.Specification;
using 通用订票.EventBus.Entity;
using 通用订票.EventBus.EventEntity;
using 通用订票.JobTask;
using 通用订票.Procedure.Entity;
using 通用订票.Procedure.Entity.QueueEntity;
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
            IServiceProvider serviceProvider)
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
        }


        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpPost(Name = "CreateOrder")]
        public async Task<object> CreateOrder([FromBody]BaseOrderCreate oc)
        {
            var userid = long.Parse(httpContextUser.ID);

            myOrderService.SetUserContext(userid);
            userinfoService.SetUserContext(userid);

            var _lock = await myOrderService.PreOrder(oc.appid);
            if (_lock == false)
            {
                return new { code = 0, message = "您的订单正在处理中,请稍后再试" };
            }

            UserOrdersCollectionSpecification us = new UserOrdersCollectionSpecification(userid, oc.appid);
            var orderCount = myOrderService.GetQueryableNt(us.ToExpression()).Select(a => a.userId);
            if (await orderCount.CountAsync() >= 5)
            {
                await myOrderService.OrderFail(oc.appid);
                return new { code = 0, message = "购票数量达到上线" };
            }

            oc.ids = oc.ids.Distinct().ToArray();
            foreach (var item in oc.ids)
            {
                UserInfoOwnByUserExistSpecification uis = new UserInfoOwnByUserExistSpecification(item, userid);
                var query = await userinfoService.Exist(uis.ToExpression());
                if (query == false)
                {
                    await myOrderService.OrderFail(oc.appid);
                    return new { code = 0, message = "所选择的用户不存在" };
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

                if(stock.day - exhibition.beforeDays < 0)
                {
                    throw new Exception("选择日期不正确");
                }

                string extraInfo = jsonSerializerProvider.Serialize(new OrderInfo { appid = oc.appid, ids = oc.ids.ToArray() });

                var order = await myOrderService.CreateOrder(
                    stock.id,
                    stock.stockName,
                    exhibition.basicPrice * oc.ids.Count,
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

                return new { status = 1, message = "下单请求成功，请等待下单结果", data = order };
            }
            catch(Exception e)
            {
                await myOrderService.OrderFail(oc.appid);
                await stockService.SaleStock(stock.id, -oc.ids.Count);
                throw e;
            }
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PayOrder")]
        public async Task<string> PayOrder(long trade_no)
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
                        var openid = httpContextUser.GetUserInfoFromToken("openid").FirstOrDefault();
                        if (config != null && !string.IsNullOrEmpty(openid))
                        {
                            result = await wechatPayService.PubPay(result, config, openid);
                            if (result != null && !string.IsNullOrEmpty(result.parameters))
                            {
                                await billService.UpdateNow(result);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("参数错误");
                        }
                        return result.parameters;
                    }
                    else
                    {
                        return result.parameters;
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
                return e.Message;
            }
            finally
            {
                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid);
            }
            return "";   
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "RefundOrder")]
        public async Task<string> RefundOrder(long trade_no)
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

                    if (order.status == OrderStatus.已付款)
                    {
                        WechatBill bill = null;
                        WechatBillRefund billRefund = null;
                        if (order.amount > 0)
                        {
                            bill = await billService.GetWechatBill(order.trade_no);
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
                        return "订单退款请求成功，请耐心等待退款";
                    }
                    else
                    {
                        throw new ArgumentException("订单已不可退款");
                    }
                }
                catch (Exception e)
                {
                    await myOrderService.AfterOrderToke(trade_no);
                    return e.Message;
                }
                finally
                {
                    await _cache.ReleaseLock("OrderLocker_" + trade_no, lockid);
                }
            }
            
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "PaidOrder")]
        public async Task<通用订票.Core.Entity.Order> PaidOrder(long trade_no)
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

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "CloseOrder")]
        public async Task<dynamic> CloseOrder(long trade_no)
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
                    )};          
                await eventPublisher.PublishAsync(new OnOrderClosedEvent(onOrderClosed));
            }
            catch(Exception e)
            {
                return e.Message;
            }
            finally
            {

                await _cache.ReleaseLock("OrderLocker_" + trade_no, lockerId);
            }

            return "关闭成功";
        }

        [HttpGet(Name = "CheckTicket")]
        [NonUnify]
        public async Task<TicketVerifyResult> CheckTicket([FromQuery] string ticket_number, [FromQuery] int count = 1, [FromQuery] string exhibition = null)
        {
            var ticket = await ticketService.TicketBeginCheck(ticket_number, count,exhibition);
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

            if (ticket.code == 1)
            {
                ticket.app = await stockService.GetAppointmentById(ticket.ticket.AppointmentId);
                ticket.exhibition = await exhibitionService.GetExhibitionByID(ticket.app.objectId);
                await eventPublisher.PublishAsync("TicketVerifyEvent", new TicketVerifyEventModel
                {
                    type = ticket.ticket.ota,
                    ticketNumber = ticket_number,
                    count = count,
                    tenant_id = tenantGetSetor.Get(),
                    exhibitionId = exhibition
                });
            }
            else
            {
                await ticketService.TicketEndCheck(ticket.ticket);
            }
            return ticket;
        }

        //[Authorize]
        //[TypeFilter(typeof(SaaSAuthorizationFilter))]
        [HttpGet(Name = "Test")]
        public async Task<string> Test(long trade_no)
        {
            var order = await PaidOrder(trade_no);
            if (order == null)
            {
                return "生成票务失败";
            }
            var app = await stockService.GetAppointmentById(order.objectId);
            var exhibition = await exhibitionService.GetExhibitionByID(app.objectId);

            var startTime = order.createTime.Value.AddDays(app.day).Date.Add(app.startTime.TimeOfDay);
            var endTime = order.createTime.Value.AddDays(app.day).Date.Add(app.endTime.TimeOfDay);

            if (exhibition.isMultiPart == true)
            {
                await _queue.PushMessage(new TicketCreateQueueEntity(new TicketCreate()
                {
                    startTime = startTime,
                    endTime = endTime,
                    exhibitions = exhibition.exhibitions.Split(' '),
                    order = order,
                    status = Base.Entity.TicketStatus.未使用,
                    tenantId = httpContextUser.TenantId,
                    uid = order.GetExtraInfo().ids,
                    userid = order.userId
                }));
            }
            else
            {
                await _queue.PushMessage(new TicketCreateQueueEntity(new TicketCreate()
                {
                    startTime = startTime,
                    endTime = endTime,
                    exhibitions = null,
                    order = order,
                    status = Base.Entity.TicketStatus.未使用,
                    tenantId = httpContextUser.TenantId,
                    uid = order.GetExtraInfo().ids,
                    userid = order.userId
                }));
            }
            return "生成票务成功";
        }
    }
}
