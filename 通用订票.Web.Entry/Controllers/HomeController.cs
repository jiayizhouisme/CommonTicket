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
using 通用订票.Core.Entity;

namespace 通用订票.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;   

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            var body = new { AType = 2, Month = 8,Year = 2024 };
            var dic = new Dictionary<string,string>();
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
            dic.Add("timestamp", timestamp);
            dic.Add("nonce", "2116743");
            dic.Add("signature", MD5Encryption.Encrypt(timestamp + "2116743" + "NMTAxOjIwMTYxMjIxMTUwMw====" + JsonConvert.SerializeObject(body)));
            var d = await "https://baochuanchangyzjq.com/api/access/CountTicket".SetHeaders(dic).SetBody(body).PostAsync();
            var result = await d.Content.ReadAsStringAsync();
             _logger.LogInformation("test");
            return View();
        }
    }
}