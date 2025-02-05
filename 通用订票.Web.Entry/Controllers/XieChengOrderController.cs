﻿using BeetleX.Redis.Commands;
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
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.DirectoryServices.Protocols;
using System.Text;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;
using 通用订票.JobTask;
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
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IXieChengOTAOrderService xieChengOTAOrderService;
        private readonly IDefaultOrderServices defaultOrderServices;
        private readonly ILogger<XieChengOrderController> _logger;
        private readonly ITenantGetSetor tenantGetSetor;
        public const string CreatePreOrder = "CreatePreOrder";
        public const string QueryOrder = "QueryOrder";
        public const string PayPreOrder = "PayPreOrder";
        public const string CancelPreOrder = "CancelPreOrder";
        public const string CancelOrder = "CancelOrder";

        private string tenant_name = null;
        public XieChengOrderController(
            IXieChengOTAOrderService xieChengOTAOrderService,
            IHttpContextAccessor httpContextAccessor,
            INamedServiceProvider<IDefaultOrderServices> _orderProvider,
            ILogger<XieChengOrderController> _logger,
            ITenantGetSetor tenantGetSetor)
        {
            this.xieChengOTAOrderService = xieChengOTAOrderService;
            this.httpContextAccessor = httpContextAccessor;
            this._logger = _logger;
            this.tenantGetSetor = tenantGetSetor;
            tenant_name = tenantGetSetor.Get();
            var factory = SaaSServiceFactory.GetServiceFactory(tenant_name);
            this.defaultOrderServices = factory.GetOrderService(_orderProvider);
        }

        [HttpPost(Name = "xiecheng")]
        [NonUnify]
        public async Task<XieChengResponse> xiecheng([FromBody] XieChengRequest request)
        {
            if (string.IsNullOrEmpty(tenant_name))
            {
                return new XieChengResponse
                {
                    header = new XieChengResponseHeader { resultCode = "9999", resultMessage = "租户异常" }
                };
            }

            string path =
                httpContextAccessor.HttpContext.Request.Scheme + "://" + 
                    httpContextAccessor.HttpContext.Request.Host.ToString() +
                    "/" +
                    tenant_name +
                    httpContextAccessor.HttpContext.Request.Path.ToString();
            
            var config = await xieChengOTAOrderService.GetConfig(tenant_name);
            bool signVerify = XieChengTool.SignVerify(request.header.accountId, request.header.serviceName,
                request.header.requestTime, request.body, request.header.version,config.ApiKey,request.header.sign);
            
            if (!signVerify)
            {
                return new XieChengResponse
                {
                    header = new XieChengResponseHeader { resultCode = "0002", resultMessage = "签名错误" }
                };
            }

            if (config.Account != request.header.accountId)
            {
                return new XieChengResponse
                {
                    header = new XieChengResponseHeader { resultCode = "0003", resultMessage = "供应商账户信息不正确" }
                };
            }

            var body = XieChengTool.AESDecrypt(request.body, config.AESKey, config.AESVector);
            defaultOrderServices.SetUserContext(-1);
            xieChengOTAOrderService.SetService(defaultOrderServices);
            xieChengOTAOrderService.SetTenant(tenant_name);
            if (request.header.serviceName == CreatePreOrder)
            {
                var createOrder = JsonConvert.DeserializeObject<XiechengCreateOrder>(body);
                var preresponse = await xieChengOTAOrderService.CreateXieChengOrder(createOrder);

                var _body = JsonConvert.SerializeObject(preresponse);
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body,config.AESKey,config.AESVector));

                return new XieChengResponse{
                    header = new XieChengResponseHeader { resultCode = "0000", resultMessage  = "success" },
                    body = body
                };

            }else if (request.header.serviceName == QueryOrder)
            {
                var queryOrder = JsonConvert.DeserializeObject<XieChengOrderQuery>(body);
                var items = await this.xieChengOTAOrderService.QueryXieChengOrder(queryOrder.otaOrderId);

                var _body = JsonConvert.SerializeObject(items.body) ;
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body, config.AESKey, config.AESVector));
                return new XieChengResponse
                {
                    header = items.header,
                    body = body
                };
            }
            else if (request.header.serviceName == PayPreOrder)
            {
                var paypreOrder = JsonConvert.DeserializeObject<XiechengPayPreOrder>(body);
                paypreOrder.http_path = path;
                string _body = null;

                //var response = await xieChengOTAOrderService.PayPreOrder(paypreOrder);
                //paypreOrder.supplierConfirmType = 2;
                //await _eventPublisher.PublishDelayAsync("XieChengPayConfirm", 500, paypreOrder);
                //_body = JsonConvert.SerializeObject(response);

                paypreOrder.supplierConfirmType = 1;
                var confirmResult = await this.xieChengOTAOrderService.PayPreConfirm(paypreOrder);
                _body = JsonConvert.SerializeObject(confirmResult.body);

                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body, config.AESKey, config.AESVector));
                return new XieChengResponse
                {
                    header = confirmResult.header,
                    body = body
                };
            }
            else if (request.header.serviceName == CancelPreOrder)
            {
                var cancelPreOrder = JsonConvert.DeserializeObject<XieChengOrderQuery>(body);
                await xieChengOTAOrderService.CanclePreOrder(cancelPreOrder);
                return new XieChengResponse{ header = new XieChengResponseHeader { resultCode = "0000", resultMessage = "success" } };
            }else if (request.header.serviceName == CancelOrder)
            {
                var cancelOrder = JsonConvert.DeserializeObject<XieChengCancelOrder>(body);

                cancelOrder.supplierConfirmType = 1;
                cancelOrder.tenant_id = tenant_name;
                var confirmResult = await this.xieChengOTAOrderService.CancleOrderConfirm(cancelOrder);
                var _body = JsonConvert.SerializeObject(confirmResult);
                body = XieChengTool.EncodeBytes(XieChengTool.AESEncrypt(_body, config.AESKey, config.AESVector));

                return new XieChengResponse
                {
                    header = new XieChengResponseHeader { resultCode = confirmResult.confirmResultCode, resultMessage = confirmResult.confirmResultMessage },
                    body = body
                };
            }
            else
            {
                return new XieChengResponse
                {
                    header = new XieChengResponseHeader { resultCode = "9999", resultMessage = "ServiceName Not Found" }
                };
            }
        }

    }
}
