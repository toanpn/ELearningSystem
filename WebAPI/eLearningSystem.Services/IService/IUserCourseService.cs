using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IUserCourseService : IBaseService<UserCourse>
    {
        List<Course> GetOwnCourses(string userName);
        int BuyCourse(int courseId, string userName);
        List<int> GetOwnCourseID(string userName);
    }
}
