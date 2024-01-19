using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Application;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}