using Core.Auth;
using Core.Queue.IQueue;
using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using 通用订票.Procedure.Entity.QueueEntity;

namespace 通用订票.Web.Entry.Controllers
{
    [Route("api/payNotify")]
    public class PayNotifyController : IDynamicApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWeChatPayNotifyClient _client;
        private readonly IOptions<WeChatPayOptions> _optionsAccessor;
        private readonly IQueuePushInfo _redisOperationRepository;
        private readonly IHttpContextUser httpContextUser;
        public PayNotifyController(IWeChatPayNotifyClient _client, IOptions<WeChatPayOptions> optionsAccessor,
            IQueuePushInfo _redisOperationRepository,IHttpContextAccessor contextAccessor, IHttpContextUser httpContextUser)
        {
            _contextAccessor = contextAccessor;
            this._client = _client;
            this._optionsAccessor = optionsAccessor;
            this._redisOperationRepository = _redisOperationRepository;
            this.httpContextUser = httpContextUser;
        }

        /// <summary>
        ///     统一下单支付结果通知
        /// </summary>
        [HttpPost]
        [NonUnify]
        [Route("Unifiedorder")]
        public async Task<IActionResult> Unifiedorder()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayUnifiedOrderNotify>(
                    _contextAccessor.HttpContext.Request, 
                    _optionsAccessor.Value
                    );
                if (notify.ReturnCode == WeChatPayCode.Success)
                {
                    var entity = new WechatPayCallBackQueueEntity(notify);

                    await _redisOperationRepository.PushMessage(entity);
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
