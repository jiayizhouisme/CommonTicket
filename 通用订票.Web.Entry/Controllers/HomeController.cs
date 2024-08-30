using DotNetCore.CAP;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.RemoteRequest.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProtoBuf.WellKnownTypes;
using Quick.RabbitMQPlus;
using System.Collections.Generic;
using System.Security.Cryptography;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}