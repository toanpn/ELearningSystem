using eLearningSystem.Data;
using eLearningSystem.Data.UnitOfWork;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.Repository;
using eLearningSystem.WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace eLearningSystem.WebApi.APIs
{
    public class UserController : ApiController
    {
        private IUserRepository userdb;
        private DbContext db;
        private IUnitOfWork<eLearningDataContext> unitOfWork;

        // GET: api/User
        public IQueryable<User> GetUsers()
        {
            var a= unitOfWork.Context.Users.ToList();
            return a.AsQueryable();
        }
        
    }
}