using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IUserRoleRepository
    {
        void AddUserRole(UserRole userRole);
        void AddUserRole(int idUser, int idRole);
        void DeleteUserRole(int idUser, int idRole);
        void DeleteUserRole(UserRole userRole);
        IEnumerable<UserRole> GetAll();
        UserRole GetUserRole(int idUser, int idRole);
        void Save();
    }
}
