using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quick.RabbitMQPlus;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICapPublisher capBus;

        public HomeController(ILogger<HomeController> logger, ICapPublisher capBus)
        {
            this.capBus = capBus;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await capBus.PublishAsync("OnOrderCreated", "123");
            _logger.LogInformation("test");
            return View();
        }
    }
}