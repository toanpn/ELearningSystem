using eLearningSystem.Data;
using eLearningSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IUserService
    {
        User UpsertUser(User User);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long UserId);
        bool AddUser(long userId, long UserId);
    }
}
