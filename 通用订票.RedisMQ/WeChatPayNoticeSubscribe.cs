using Core.Auth;
using Core.Cache;
using Core.Services.ServiceFactory;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using Furion.DatabaseAccessor;
using Furion.JsonSerialization;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Procedure.Entity.QueueEntity;
using 通用订票.Procedure.Entity;
using 通用订票.Core.Entity;
using Core.Queue.IQueue;
using Furion.DependencyInjection;
using ProtoBuf.Serializers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using 通用订票.Application.System.Factory.Service;

namespace 通用订票.RedisMQ
{
    public class WeChatPayNoticeSubscribe : IRedisSubscribe
    {
        private readonly IJsonSerializerProvider jsonSerializerProvider;
        private readonly ILogger<WeChatPayNoticeSubscribe> _logger;
        private readonly ICacheOperation _cache;
        private readonly IServiceProvider _serviceProvider;
        private readonly IQueuePushInfo _queue;

        public WeChatPayNoticeSubscribe(ILogger<WeChatPayNoticeSubscribe> _logger, IServiceProvider _serviceProvider, IJsonSerializerProvider jsonSerializerProvider,
            ICacheOperation _cache, IQueuePushInfo _queue)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
            this.jsonSerializerProvider = jsonSerializerProvider;
            this._queue = _queue;
        }

        [Subscribe("WeChatPayNotice")]
        public async Task WeChatPayNotice(string msg)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var notify = jsonSerializerProvider.Deserialize<WeChatPayUnifiedOrderNotify>(msg);
                var billattach = jsonSerializerProvider.Deserialize<WechatBillAttach>(notify.Attach);
                Core.Entity.Order order = null;

                var factory = SaaSServiceFactory.GetServiceFactory(billattach.tenant_id);

                var _stockProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultAppointmentService>>();
                var s_service = factory.GetStockService(_stockProvider);
                s_service = ServiceFactory.GetNamedSaasService<IDefaultAppointmentService, Appointment>
                    (scope.ServiceProvider, s_service, billattach.tenant_id);

                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var o_service = factory.GetOrderService(_orderProvider);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, billattach.tenant_id);

                var wechatBillService = ServiceFactory.GetSaasService<IWechatBillService,WechatBill>
                    (scope.ServiceProvider,billattach.tenant_id);

                var e_service = ServiceFactory.GetSaasService<IExhibitionService, Exhibition>(scope.ServiceProvider, billattach.tenant_id);
                if (notify is { ReturnCode: WeChatPayCode.Success })
                {
                    if (notify.ResultCode == WeChatPayCode.Success)
                    {
                        //支付成功
                        string lockerId = Guid.NewGuid().ToString();
                        await _cache.Lock("OrderLocker_" + billattach.trade_no, lockerId);
                        try
                        {
                            order = await o_service.GetOrderById(billattach.trade_no);
                            if (order.status != 通用订票Order.Entity.OrderStatus.未付款 &&
                                order.status != 通用订票Order.Entity.OrderStatus.已关闭)
                            {
                                await Task.CompletedTask;
                                return;
                            }

                            if (order.status == 通用订票Order.Entity.OrderStatus.已关闭)
                            {
                                await s_service.SaleStockAndUpdate(order.objectId, order.GetExtraInfo().ids.Count());
                            }

                            var result = await o_service.PayFinished(order);
                            await wechatBillService.UpdateStatus(BillPaymentsStatus.Payed,order.trade_no,notify.TransactionId);

                            var app = await s_service.GetAppointmentById(order.objectId);
                            var exhibition = await e_service.GetExhibitionByID(app.objectId);

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
                                    //realTenantId = httpContextUser.RealTenantId,
                                    status = Base.Entity.TicketStatus.未使用,
                                    tenantId = billattach.tenant_id,
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
                                    //realTenantId = httpContextUser.RealTenantId,
                                    status = Base.Entity.TicketStatus.未使用,
                                    tenantId = billattach.tenant_id,
                                    uid = order.GetExtraInfo().ids,
                                    userid = order.userId
                                }));
                            }
                        }
                        catch (Exception e)
                        {
                            await o_service.AfterOrderToke(billattach.trade_no);
                        }
                        finally
                        {
                            await _cache.ReleaseLock("OrderLocker_" + billattach.trade_no, lockerId);
                        }
                    }
                    else
                    {
                        //支付失败
                        var message = notify.ErrCode + ":" + notify.ErrCodeDes;
                        await wechatBillService.UpdateStatus(BillPaymentsStatus.Other, order.trade_no, notify.TransactionId);
                        _logger.LogError(message);
                    }
                }
            }
        }
    }
}
