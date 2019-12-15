using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {


        private readonly DbContext _context;
        private readonly IDbSet<User> _dbset;
        public UserRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<User>();
        }

        public User GetUserByUserName(string userName)
        {
            return this._dbset.Where(m => m.UserName == userName).FirstOrDefault();
        }
    }
}
