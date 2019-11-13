using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        void AddNewRole(string nameRole);
        void DeleteRoleByName(string nameRole);
        Role GetRoleByName(string nameRole);
    }
}
