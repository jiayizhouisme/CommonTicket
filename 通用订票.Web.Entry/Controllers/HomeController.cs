using DotNetCore.CAP;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quick.RabbitMQPlus;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICapPublisher capBus;
        private readonly IDefaultOrderServices orderServices;
        private DbContext context { get; set; }

        public HomeController(
            ILogger<HomeController> logger, 
            ICapPublisher capBus,
            IDefaultOrderServices orderServices)
        {
            this.capBus = capBus;
            _logger = logger;
            this.orderServices = orderServices;

        }

        public async Task<IActionResult> Index()
        {
            using (var transaction = orderServices.GetRepository().Database.BeginTransaction(capBus, autoCommit: false))
            {
                var id = Guid.Parse("3DC16154-C4F5-42D6-BEEC-CC3B09D2D2D6");
                await orderServices.CreateOrder(id,"1231231231",1);
                await capBus.PublishAsync("testCap", "123");
                await transaction.CommitAsync();
            }

            _logger.LogInformation("test");
            return View();
        }
    }
}