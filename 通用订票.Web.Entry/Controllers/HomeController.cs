using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.RabbitMQPlus;
using 通用订票.Application.System.Models;
using 通用订票.RedisMQ.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IQuickRabbitMQPlus _queuePushInfo;
        public HomeController(IQuickRabbitMQPlus _queuePushInfo, ILogger<HomeController> logger)
        {
            this._queuePushInfo = _queuePushInfo;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("test");
            var entity1 = new RabbitMQTestEntity1();
            var entity2 = new RabbitMQTestEntity2();
            entity1.entity = new OrderCreate() { realTenantId = "mylittle shit1"};
            await _queuePushInfo.Send(entity1, "TestRouteKey1");
            await _queuePushInfo.Send(entity2, "TestRouteKey2");
            return View();
        }
    }
}