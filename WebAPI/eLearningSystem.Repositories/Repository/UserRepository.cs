using eLearningSystem.Data;
using eLearningSystem.Data.GerenicRepository;
using eLearningSystem.Data.UnitOfWork;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork<eLearningDataContext> unitOfWork)
        : base(unitOfWork)
        {
        }
        public UserRepository(eLearningDataContext context)
        : base(context)
        {
        }
        public IEnumerable<User> GetEmployeesByGender(bool Gender)
        {
            return Context.Users.Where(emp => emp.gender == Gender).ToList();
        }
      
    }
}
