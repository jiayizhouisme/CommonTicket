using Core.Auth;
using Core.HttpTenant;
using Core.Queue.IQueue;
using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using Furion.DataValidation;
using Furion.DynamicApiController;
using Furion.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Profiling.Internal;
using 通用订票.Application.System.Services.IService;
using 通用订票.Procedure.Entity.QueueEntity;

namespace 通用订票.Web.Entry.Controllers
{
    [Route("api/payNotify")]
    public class PayNotifyController : IDynamicApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWeChatPayNotifyClient _client;
        private readonly IWechatMerchantConfigService wechatMerchantConfigService;
        private readonly IQueuePushInfo _redisOperationRepository;
        public PayNotifyController(IWeChatPayNotifyClient _client, IWechatMerchantConfigService wechatMerchantConfigService,
            IQueuePushInfo _redisOperationRepository,IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            this.wechatMerchantConfigService = wechatMerchantConfigService;
            this._client = _client;
            this._redisOperationRepository = _redisOperationRepository;
        }

        /// <summary>
        ///     统一下单支付结果通知
        /// </summary>
        [HttpPost]
        [NonUnify]
        [Route("Unifiedorder")]
        public async Task<IActionResult> Unifiedorder()
        {
            Log.Information("支付回调!");
            var config = await wechatMerchantConfigService.GetConfig();
            WeChatPayOptions _wechatpay = new WeChatPayOptions();
            _wechatpay.APIKey = config.apiKey;
            _wechatpay.MchId = config.mchId;
            _wechatpay.AppId = config.appid;
            _wechatpay.RsaPublicKey = config.rsaPublicKey;
            _wechatpay.Certificate = config.certificate;
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayUnifiedOrderNotify>(
                    _contextAccessor.HttpContext.Request,
                    _wechatpay
                    );
                Log.Information(notify.ToJson());
                if (notify.ReturnCode == WeChatPayCode.Success)
                {
                    Log.Information("回调参数验证成功");
                    var entity = new WechatPayCallBackQueueEntity(notify);

                    await _redisOperationRepository.PushMessage(entity);
                    return WeChatPayNotifyResult.Success;
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new NoContentResult();
            }
        }
    }
}
