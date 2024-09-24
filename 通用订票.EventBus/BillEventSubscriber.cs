using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.JsonSerialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;
using 通用订票.EventBus.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.EventBus
{
    public class BillEventSubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceProvider _serviceProvider;
        public BillEventSubscriber(
            IServiceProvider _serviceProvider
            )
        {
            this._serviceProvider = _serviceProvider;
        }

        [EventSubscribe("OnOrderClosed")]
        public async Task Bill_OnOrderClosed(EventHandlerExecutingContext context)
        {
            var closedEntity = (OnOrderClosed)context.Source.Payload;
            if (closedEntity.order.amount > 0)
            {
                using (var scope = this._serviceProvider.CreateScope())
                {
                    var bill_service = ServiceFactory.GetSaasService<IWechatBillService, WechatBill>(scope.ServiceProvider, closedEntity.tenantId);
                    await bill_service.UpdateStatus(BillPaymentsStatus.NoPay, closedEntity.order.trade_no);
                }
            }
        }

        [EventSubscribe("OnOrderRefunded")]
        public async Task Bill_OnOrderRefunded(EventHandlerExecutingContext context)
        {
            var closedEntity = (OnOrderRefunded)context.Source.Payload;
            if (closedEntity.order.amount > 0)
            {
                using (var scope = this._serviceProvider.CreateScope())
                {
                    var refundBill_service = ServiceFactory.GetSaasService<IWechatRefundBillService, WechatBillRefund>(scope.ServiceProvider, closedEntity.tenantId);
                    await refundBill_service.UpdateStatus(RefundStatus.已退款, closedEntity.billRefund.tradeNo);
                }
            }
        }
    }
}
