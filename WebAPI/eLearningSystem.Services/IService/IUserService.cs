using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService 
{
    public interface IUserService 
    {
        void Create(User entity);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Update(User entity);
        IEnumerable<User> GetByRole(int idRole);
        User GetUserByUserName(string userName);

        User GetTeacherByCourseId(int id);
    }
}
