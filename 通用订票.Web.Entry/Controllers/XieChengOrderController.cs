using BeetleX.Redis.Commands;
using Core.Auth;
using Core.Cache;
using Core.Queue.IQueue;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.DirectoryServices.Protocols;
using System.Text;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Service;
using 通用订票.OTA.携程.Tool;
using 通用订票Order.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [Route("api")]
    public class XieChengOrderController : IDynamicApiController
    {
        private readonly IHttpContextUser httpContextUser;
        private readonly IXieChengOTAOrderService xieChengOTAOrderService;
        private readonly IDefaultOrderServices defaultOrderServices;
        private readonly ILogger<XieChengOrder> logger;
        private readonly IJsonSerializerProvider _serializerProvider;
        private readonly IEventPublisher _eventPublisher;
        public const string CreatePreOrder = "CreatePreOrder";
        public const string QueryOrder = "QueryOrder";
        public const string PayPreOrder = "PayPreOrder";
        public const string CancelPreOrder = "CancelPreOrder";
        public XieChengOrderController(
            IXieChengOTAOrderService xieChengOTAOrderService,
            IHttpContextUser httpContextUser,
            INamedServiceProvider<IDefaultOrderServices> _orderProvider,
            ILogger<XieChengOrder> logger, 
            IJsonSerializerProvider _serializerProvider,
            IEventPublisher _eventPublisher)
        {
            this.xieChengOTAOrderService = xieChengOTAOrderService;
            this.httpContextUser = httpContextUser;
            this.logger = logger;
            this._serializerProvider = _serializerProvider;
            this._eventPublisher = _eventPublisher;
            var factory = SaaSServiceFactory.GetServiceFactory(httpContextUser.TenantId);
            this.defaultOrderServices = factory.GetOrderService(_orderProvider);
        }
        [HttpPost(Name = "test")]
        public async Task<object> test(XieChengPayPreConfirm json)
        {
            var config = await xieChengOTAOrderService.GetConfig(httpContextUser.TenantId);
            var body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(JsonConvert.SerializeObject(json), config.AESKey, config.AESVector));
            return body;
        }

        [HttpPost(Name = "xiecheng")]
        [NonUnify]
        public async Task<dynamic> xiecheng([FromBody] XieChengRequest request)
        {
            var config = await xieChengOTAOrderService.GetConfig(httpContextUser.TenantId);
            bool signVerify = XieChengTool.SignVerify(request.header.accountId, request.header.serviceName,
                request.header.requestTime, request.body, request.header.version,config.ApiKey,request.header.sign);

            if (!signVerify)
            {
                return null;
            }

            logger.LogInformation(_serializerProvider.Serialize(request));
            var body = XieChengTool.AESDecrypt(request.body, config.AESKey, config.AESVector);
            logger.LogInformation(body);
            xieChengOTAOrderService.SetService(defaultOrderServices);
            if (request.header.serviceName == CreatePreOrder)
            {
                var createOrder = JsonConvert.DeserializeObject<XiechengCreateOrder>(body);
                if (await xieChengOTAOrderService.Exist(a => a.otaOrderId == createOrder.otaOrderId))
                {
                    var supp = await xieChengOTAOrderService.GetQueryableNt(a => a.otaOrderId == createOrder.otaOrderId).Select(a => a.trade_no).FirstOrDefaultAsync();
                    var __body = JsonConvert.SerializeObject(new { createOrder.otaOrderId, supplierOrderId = supp.ToString() });
                    body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(__body, config.AESKey, config.AESVector));
                    return new { header = new { resultCode = "0000", resultMessage = "success" }, body };
                }
                
                var orders = await xieChengOTAOrderService.CreateXieChengOrder(createOrder);
                long supplierOrderId = 0;
                foreach (var order in orders)
                {
                    supplierOrderId = order.trade_no;
                }
                
                var _body = JsonConvert.SerializeObject(new { createOrder.otaOrderId, supplierOrderId = supplierOrderId.ToString() });
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body,config.AESKey,config.AESVector));

                return new { header = new { resultCode = "0000", resultMessage  = "success" }, body };
            }else if (request.header.serviceName == QueryOrder)
            {
                var queryOrder = JsonConvert.DeserializeObject<XieChengOrderQuery>(body);
                var items = await this.xieChengOTAOrderService.QueryXieChengOrder(queryOrder.otaOrderId);
                var _body = JsonConvert.SerializeObject(new
                {
                    queryOrder.otaOrderId,
                    supplierOrderId = queryOrder.supplierOrderId.ToString(),
                    items = items
                }) ;
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body, config.AESKey, config.AESVector));
                return new { header = new { resultCode = "0000", resultMessage = "success" }, body };
            }
            else if (request.header.serviceName == PayPreOrder)
            {
                var paypreOrder = JsonConvert.DeserializeObject<XiechengPayPreOrder>(body);

                var orders = await xieChengOTAOrderService.GetWithCondition(a => a.otaOrderId == paypreOrder.otaOrderId);
                string supplierOrderId = null;
                foreach (var item in paypreOrder.items)
                {
                    var first = orders.Where(a => a.PLU == item.PLU).FirstOrDefault();
                    supplierOrderId = first.trade_no.ToString();
                    if (first != null && first.orderStatus == XieChengOrderStatus.待支付)
                    {
                        first.orderStatus = XieChengOrderStatus.支付待确认;
                        first.PLU = item.PLU;
                        first.itemId = item.itemId;
                        await xieChengOTAOrderService.UpdateNow(first);
                    }
                }
                paypreOrder.tenant_id = httpContextUser.TenantId;
                await _eventPublisher.PublishDelayAsync("XieChengPayConfirm", 200,paypreOrder);

                var _body = JsonConvert.SerializeObject(new
                {
                    paypreOrder.otaOrderId,
                    supplierOrderId = supplierOrderId,
                    supplierConfirmType = 2
                });
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body, config.AESKey, config.AESVector));
                return new { header = new { resultCode = "0000", resultMessage = "success" }, body };

            }else if (request.header.serviceName == CancelPreOrder)
            {
                var canclePreOrder = JsonConvert.DeserializeObject<XieChengBodyBase>(body);
                await xieChengOTAOrderService.CanclePreOrder(canclePreOrder.otaOrderId);
                return new { header = new { resultCode = "0000", resultMessage = "success" } };
            }
            return new { status = 1,message = "下单请求成功，请等待下单结果", body };
        }
    }
}
