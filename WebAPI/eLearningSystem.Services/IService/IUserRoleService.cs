using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Services.IService
{
    public interface IUserRoleService
    {
        void Create(UserRole entity);
        void CreateByNameRole(int idUser, string nameRole);
        void Create(int idUser,int idRole);
        void Delete(UserRole entity);
        void Delete(int idUser, int idRole);
        IEnumerable<UserRole> GetAll();
    }
}
