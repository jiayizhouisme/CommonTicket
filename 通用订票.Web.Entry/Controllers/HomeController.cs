using Core.Auth;
using Core.HttpTenant;
using Core.MiddelWares;
using Core.Services.ServiceFactory;
using DotNetCore.CAP;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.EventBus;
using Furion.RemoteRequest.Extensions;
using Furion.TaskQueue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProtoBuf.Serializers;
using ProtoBuf.WellKnownTypes;
using Quick.RabbitMQPlus;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using 通用订票.Application.System.Factory.Service;
using 通用订票.Application.System.IService.Factory;
using 通用订票.Application.System.Models;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Application.System.Services.IService;
using 通用订票.Application.System.Services.Service;
using 通用订票.Core.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace 通用订票.Web.Entry.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}