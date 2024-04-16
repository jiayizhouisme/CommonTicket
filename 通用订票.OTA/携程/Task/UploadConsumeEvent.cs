using Core.Cache;
using Core.Queue.IQueue;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProtoBuf.Serializers;
using StackExchange.Redis;
using System.Net.Sockets;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;

namespace 通用订票.JobTask
{
    public class UploadConsumeEvent : IEventSubscriber, ISingleton
    {
        private readonly ICacheOperation _cache;
        private readonly IServiceScopeFactory ScopeFactory;
        public UploadConsumeEvent(ICacheOperation _cache, IServiceScopeFactory ScopeFactory)
        {
            this.ScopeFactory = ScopeFactory;
            this._cache = _cache;
        }

        [EventSubscribe("UploadConsumeEvent")]
        public async Task upload(EventHandlerExecutingContext context)
        {
            XieChengConfig config = null;
            XieChengTicketVerifyEvent model = (XieChengTicketVerifyEvent)context.Source.Payload;
            using (var scope = ScopeFactory.CreateScope())
            {
                var xiechengOrderService = ServiceFactory.GetSaasService<IXieChengOTAOrderService,XieChengOrder>
                    (scope.ServiceProvider,model.tenant_id);

                var xiechengOrder = await xiechengOrderService.GetQueryableNt
                    (a => a.trade_no == model.xiechengOrder.trade_no).FirstOrDefaultAsync();

                if (xiechengOrder.useQuantity != model.xiechengOrder.useQuantity)
                {
                    await Task.CompletedTask;
                    return;
                }
                var service = scope.ServiceProvider.GetService<IXieChengOTAOrderService>();
                config = await service.GetConfig(model.tenant_id);
            }
            #region 1
            var noticeItem = new XieChengOrderConsumedNoticeItem
            {
                itemId = model.xiechengOrder.itemId,
                quantity = model.xiechengOrder.quantity,
                useQuantity = model.xiechengOrder.useQuantity
            };

            XieChengPassenger pass = new XieChengPassenger();
            pass.passengerId = model.xiechengTicket.OTAPassengerId;
            XieChengVouchers voucher = new XieChengVouchers();
            voucher.voucherId = model.xiechengTicket.ticket.ticketNumber;

            noticeItem.passengers = [pass];
            noticeItem.vouchers = [voucher];

            XieChengOrderConsumedNotice xn = new XieChengOrderConsumedNotice();
            xn.sequenceId = DateTime.Now.ToString("yyyyMMdd")
                + Guid.NewGuid().ToString().ToLower().Replace("-", "");
            xn.otaOrderId = model.xiechengOrder.otaOrderId;
            xn.supplierOrderId = model.xiechengOrder.trade_no.ToString();
            xn.items = [noticeItem];

            #endregion

            var rawstr = XieChengTool.AESEncrypt(JsonConvert.SerializeObject(xn), config.AESKey, config.AESVector);
            var body = XieChengTool.EncodeBytes(rawstr);

            XieChengRequest xr = new XieChengRequest();
            xr.header = new XieChengHeader();
            xr.header.requestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xr.header.serviceName = "OrderConsumedNotice";
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
            await xr.Request();
        }
    }

    public struct XieChengTicketVerifyEvent
    {
        public string tenant_id { get; set; }
        public XieChengOrder xiechengOrder { get; set; }
        public XieChengTicket xiechengTicket { get; set; }
    }
}
