using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IUserCourseRepository : IGenericRepository<UserCourse>
    {
        List<UserCourse> GetOwnCourses(int id);
    }
}
