using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.IService;
using eLearningSystem.Services.Service;
using System.Web.Http;

namespace eLearningSystem.WebApi.APIs
{
    public class UserController : ApiController
    {
        //private IUserRepository _repository;
        private readonly IUserService service;

        private readonly UnitOfWork uow;

        public UserController()
        {
            uow = new UnitOfWork();
            this.service = new UserService(uow);
        }
        
        // GET: api/User
        public IHttpActionResult GetUsers()
        {
            return Ok(new { results = 12 });
        }
    }
}