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
    public interface IRoleService
    {
        void Create(Role entity);
        void Delete(Role entity);
        void DeleteById(int id);
        void DeleteByName(string name);
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        void Update(Role entity);
    }
}
