using Azure.Core;
using BeetleX.EventArgs;
using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DataValidation;
using Furion.DynamicApiController;
using Furion.TaskQueue;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using Core.Cache;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    public class PayNotifyController : IDynamicApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWeChatPayNotifyClient _client;
        private readonly IOptions<WeChatPayOptions> _optionsAccessor;
        private readonly RedisOperationRepository _redisOperationRepository;
        public PayNotifyController(IWeChatPayNotifyClient _client, IOptions<WeChatPayOptions> optionsAccessor,
            RedisOperationRepository _redisOperationRepository,IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            this._client = _client;
            this._optionsAccessor = optionsAccessor;
            this._redisOperationRepository = _redisOperationRepository;
        }

        /// <summary>
        ///     统一下单支付结果通知
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Unifiedorder()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayUnifiedOrderNotify>(_contextAccessor.HttpContext.Request, _optionsAccessor.Value);
                if (notify.ReturnCode == WeChatPayCode.Success)
                {
                    await _redisOperationRepository.ListLeftPushAsync("WeChatPayNotice", JsonConvert.SerializeObject(notify));
                    return WeChatPayNotifyResult.Success;
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new NoContentResult();
            }
        }
    }
}
