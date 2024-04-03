using Core.Cache;
using Core.Services.ServiceFactory;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.RemoteRequest.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.Services.IService;
using 通用订票.Base.Entity;
using 通用订票.Core.Entity;
using 通用订票.OTA.携程.Entity;
using 通用订票.OTA.携程.IService;
using 通用订票.OTA.携程.Model;
using 通用订票.OTA.携程.Tool;

namespace 通用订票.EventBus
{
    public class XieChengPaySubscriber : IEventSubscriber, ISingleton
    {
        private readonly IServiceScopeFactory ScopeFactory;
        private readonly ICacheOperation _cache;
        private readonly ILogger<XieChengPaySubscriber> _logger;
        
        public XieChengPaySubscriber(
            IServiceScopeFactory scopeFactory,
            ILogger<XieChengPaySubscriber> logger,
            ICacheOperation _cache)
        {
            _logger = logger;
            this.ScopeFactory = scopeFactory;
            this._cache = _cache;
        }

        [EventSubscribe("XieChengPayConfirm")]
        public async Task XieChengPayConfirm(EventHandlerExecutingContext context)
        {
            var todo = context.Source;
            var data = (XiechengPayPreOrder)todo.Payload;
            
            using (var scope = this.ScopeFactory.CreateScope())
            {
                #region 获取services
                var factory = SaaSServiceFactory.GetServiceFactory(data.tenant_id);
                var dbcontext = Db.GetDbContext(scope.ServiceProvider);
                var _ticketProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultTicketService>>();
                var t_service = factory.GetTicketService(_ticketProvider);
                t_service = ServiceFactory.GetNamedSaasService<IDefaultTicketService, Ticket>(scope.ServiceProvider, t_service, data.tenant_id);

                var _orderProvider = scope.ServiceProvider.GetService<INamedServiceProvider<IDefaultOrderServices>>();
                var o_service = factory.GetOrderService(_orderProvider);
                o_service = ServiceFactory.GetNamedSaasService<IDefaultOrderServices, Core.Entity.Order>(scope.ServiceProvider, o_service, data.tenant_id);

                var xiechengService = scope.ServiceProvider.GetService<IXieChengOTAOrderService>();

                #endregion

                var order = await o_service.GetOrderById(long.Parse(data.supplierOrderId));
                t_service.SetUserContext(Guid.Empty);

                XieChengPayPreConfirm confirm = new XieChengPayPreConfirm();
                confirm.otaOrderId = data.otaOrderId;
                confirm.supplierOrderId = data.supplierOrderId;
                confirm.confirmResultCode = "0";
                confirm.confirmResultMessage = "success";
                confirm.voucherSender = 1;

                List<XieChengVouchers> ticketList = new List<XieChengVouchers>();
                List<XieChengPayPreConfirmItems> itemList = new List<XieChengPayPreConfirmItems>();

                await _cache.Lock("XieChengPayConfirm_Lock:" + data.otaOrderId, data.otaOrderId);
                var xiechengOrders = await xiechengService.GetWithCondition(a => a.otaOrderId == data.otaOrderId);
                foreach (var item in data.items)
                {
                    ICollection<Ticket> tickets;
                    var _pluorder = xiechengOrders.Where(a => a.itemId == item.itemId).FirstOrDefault();
                    if (_pluorder.orderStatus != XieChengOrderStatus.支付待确认)
                    {
                        tickets = await t_service.GetTickets(order.trade_no);
                    }
                    else
                    {
                        var passids = _pluorder.passengerIds.Split(" ");
                        var startTime = DateTime.Parse(_pluorder.useStartDate);
                        var endTime = DateTime.Parse(_pluorder.useEndDate);
                        tickets = await t_service.GenarateTickets(startTime,
                            endTime,
                            order,
                            _pluorder.quantity,
                            passids,
                            TicketStatus.未使用,
                            OTAType.XieCheng);
                    }
                        
                    foreach (var ticket in tickets)
                    {
                        ticketList.Add(new XieChengVouchers
                        {
                            itemId = item.itemId,
                            voucherCode = ticket.ticketNumber,
                            voucherType = 2,
                        });
                    }
                        
                    itemList.Add(new XieChengPayPreConfirmItems() { 
                        itemId = item.itemId,
                        isCredentialVouchers = 0
                    });
                }
                var config = await xiechengService.GetConfig(data.tenant_id);

                confirm.vouchers = ticketList.ToArray();
                confirm.sequenceId = data.sequenceId;
                confirm.items = itemList.ToArray();
                var rawstr = XieChengTool.AESEncrypt(JsonConvert.SerializeObject(confirm), config.AESKey, config.AESVector);
                var body = XieChengTool.EncodeBytes(rawstr);

                XieChengRequest xr = new XieChengRequest();
                xr.header = new XieChengHeader();
                xr.header.requestTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                xr.header.serviceName = "PayPreOrderConfirm";
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
                var response = await xr.Request();
                if (response.header.resultCode == "0000")
                {   
                    foreach (var _order in xiechengOrders)
                    {
                        if (_order.orderStatus == XieChengOrderStatus.支付待确认)
                        {
                            _order.orderStatus = XieChengOrderStatus.支付已确认;
                            await xiechengService.UpdateNow(_order);
                            await o_service.PayFinished(order);
                        }
                    }
                }
                await _cache.ReleaseLock("XieChengPayConfirm_Lock:" + data.otaOrderId,data.otaOrderId);
            }       
        }
    }
}
