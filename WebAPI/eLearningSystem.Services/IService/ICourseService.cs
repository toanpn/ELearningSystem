using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Models;
using eLearningSystem.Services.Base;
using System.Collections.Generic;

namespace eLearningSystem.Services.IService
{
    public interface ICourseService : IBaseService<Course>
    {
        PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize);
        ICollection<Course> GetListCourseHot();
        ICollection<Course> GetListCourseNew();
    }
}