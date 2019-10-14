using eLearningSystem.Data;
using eLearningSystem.Data.GerenicRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetEmployeesByGender(bool Gender);
    }
}
