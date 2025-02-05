﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Order.IService;
using Core.Auth;

namespace 通用订票.Application.System.Services.IService
{
    public interface IDefaultOrderServices : IOrderService<Core.Entity.Order>,IUserContext<long>
    {
        Task<Core.Entity.Order> GetOrderById(long orderId);
        Task<bool> PreOrder(string objectId);
        Task OrderFail(string objectId);
        Task AfterOrdered(string objectId);
        Task DelOrderFromCache(long trande_no);
    }
}
