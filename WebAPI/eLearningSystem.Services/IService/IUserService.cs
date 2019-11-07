using eLearningSystem.Data;
using eLearningSystem.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IUserService
    {
        IdentityUser GetUsers(string UserId);
        bool DeleteUser(string UserId);
        bool AddUser(string userName, string email, string password);
        IEnumerable<IdentityUser> GetUsersByRole(string RoleId);
        bool UpdateUser(User user);
    }
}
