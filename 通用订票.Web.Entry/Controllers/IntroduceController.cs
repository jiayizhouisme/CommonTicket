using Core.Auth;
using Core.MiddelWares;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using 通用订票.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace 通用订票.Web.Entry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroduceController : IDynamicApiController
    {
        IRepository<Introduce,MasterDbContextLocator> _repository;
        public IntroduceController(IRepository<Introduce, MasterDbContextLocator> _repository)
        {
            this._repository = _repository;
        }
        // GET: api/<IntroduceController>
        [HttpGet(Name = "Get")]
        [NonUnify]
        public async Task<PagedList<Introduce>> Get(int pageIndex = 1, int pageSize = 10, int ID = 0, int type = 0)
        {
            var temp = _repository.AsQueryable();
            if (ID != 0)
            {
                temp = temp.Where(a => a.id == ID);
            }

            return await temp.ToPagedListAsync(pageIndex,pageSize);
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpPost(Name = "Add")]
        public async Task<Introduce> Add(Introduce introduce)
        {
            
            return (await _repository.InsertNowAsync(introduce)).Entity;
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpPost(Name = "Update")]
        public async Task<Introduce> Update(Introduce introduce)
        {
            return (await _repository.UpdateNowAsync(introduce)).Entity;
        }

        [Authorize]
        [TypeFilter(typeof(SaaSAuthorizationFilter))]
        [TypeFilter(typeof(PermissionAuthFilter), Arguments = new object[] { new Permissions[] { Permissions.Administrator } })]
        [HttpGet(Name = "Delete")]
        public async Task<bool> Delete(int id)
        {
            await _repository.DeleteNowAsync(id);
            return true;
        }
    }
}
