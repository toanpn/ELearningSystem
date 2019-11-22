using eLearningSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IUserRepository 
    {
        void Add(User user);
        void Edit(int id, User user);
        User Delete(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        IEnumerable<User> FindBy(System.Linq.Expressions.Expression<Func<User, bool>> predicate);
        void Save();
        User GetUserByUserName(string userName);
    }
}
