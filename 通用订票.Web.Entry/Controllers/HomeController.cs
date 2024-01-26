using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.RabbitMQPlus;
using 通用订票.Application;
using 通用订票.Application.System.Models;
using 通用订票.RedisMQ.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IQuickRabbitMQPlus _queuePushInfo;
        public HomeController(IQuickRabbitMQPlus _queuePushInfo)
        {
            this._queuePushInfo = _queuePushInfo;
        }
        public IActionResult Index()
        {
            var entity1 = new RabbitMQTestEntity1();
            var entity2 = new RabbitMQTestEntity2();
            entity1.entity = new OrderCreate() { realTenantId = "mylittle shit"};
            _queuePushInfo.Send(entity1, "TestRouteKey1");
            _queuePushInfo.Send(entity2, "TestRouteKey2");
            return View();
        }
    }
}