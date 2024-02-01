using Core.Cache;
using Core.Services.ServiceFactory;
using Essensoft.Paylink.WeChatPay.V2;
using Essensoft.Paylink.WeChatPay.V2.Notify;
using Furion.DatabaseAccessor;
using InitQ.Abstractions;
using InitQ.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using 通用订票.Application.System.Services.IService;

namespace 通用订票.RedisMQ
{
    public class WeChatPayNoticeSubscribe : IRedisSubscribe
    {
        private readonly ILogger<WeChatPayNoticeSubscribe> _logger;
        private readonly ICacheOperation _cache;
        private DbContext dbContext;
        private readonly IServiceProvider _serviceProvider;

        public WeChatPayNoticeSubscribe(ILogger<WeChatPayNoticeSubscribe> _logger, IServiceProvider _serviceProvider,
            ICacheOperation _cache)
        {
            this._logger = _logger;
            this._cache = _cache;
            this._serviceProvider = _serviceProvider;
        }

        [Subscribe("WeChatPayNotice")]
        private async Task WeChatPayNotice(string msg)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                dbContext = Db.GetDbContext(scope.ServiceProvider);

                var o_service = ServiceFactory.GetSaasService<IMyOrderServices, Core.Entity.Order>(scope.ServiceProvider, "默认租户");
                var t_service = ServiceFactory.GetSaasService<IMyTicketService, Core.Entity.Ticket>(scope.ServiceProvider, "默认租户");


                Core.Entity.Order order = null;
                var notify = JsonConvert.DeserializeObject<WeChatPayUnifiedOrderNotify>(msg);

                if (notify is { ReturnCode: WeChatPayCode.Success })
                {
                    if (notify.ResultCode == WeChatPayCode.Success)
                    {
                        //支付成功
                        string lockerId = Guid.NewGuid().ToString();
                        await _cache.Lock("OrderLocker_" + notify.Attach, lockerId);
                        try
                        {
                            order = await o_service.GetOrderById(long.Parse(notify.Attach));
                            var tickets = await t_service.GetTickets(order.trade_no);

                            var result = await o_service.PayFinished(order);
                            var ticket = await t_service.EnableTickets(tickets);
                        }
                        catch (Exception e)
                        {
                            await o_service.AfterOrderToke(order.trade_no);
                        }
                        finally
                        {
                            await t_service.AfterTicketToke(order.trade_no);
                            await _cache.ReleaseLock("OrderLocker_" + notify.Attach, lockerId);
                        }
                    }
                    else
                    {
                        //支付失败
                    }
                }
            }
        }
    }
}
