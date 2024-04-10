using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Application.System.ServiceBases.IService;
using 通用订票.Core.Entity;
using Core.Auth;

namespace 通用订票.Application.System.Services.IService
{
    public interface IDefaultAppointmentService : IStockService<Appointment>,IUserContext<Guid>
    {
        Task<Appointment> GetAppointmentById(string appid);
        Task<IQueryable<Appointment>> GetAppointmentsByDay(Guid exhibtionID,int day);
        Task<IQueryable<Appointment>> GetAppointmentsByDate(Guid exhibitionID, DateTime date);
        /// <summary>
        /// 循环刷新每天的库存
        /// </summary>
        /// <param name="exhibitionID"></param>
        /// <returns></returns>
        Task RefreshAppoints(Guid exhibitionID);
    }
}
