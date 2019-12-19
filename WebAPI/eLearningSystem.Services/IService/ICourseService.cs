using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface ICourseService : IBaseService<Course>
    {
        PagedResults<Course> CreatePagedResults(int pageNumber, int pageSize);

        PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize);
        ICollection<Course> GetListCourseHot();
        ICollection<Course> GetListCourseNew();
        List<Course> GetListCourseFree();
        PagedResults<Course> GetListCourseByCategory(int id, int pageNumber, int pageSize);
        PagedResults<Course> GetListCourseHotPageResult(int pageNumber, int pageSize);
        PagedResults<Course> GetListCourseNewPageResult(int pageNumber, int pageSize);
        PagedResults<Course> GetListCourseFreePageResult(int pageNumber, int pageSize);
        Teacher GetTeacherByCourseId(int courseId);
        PagedResults<Course> GetCoursesCategory(int pageNumber, int pageSize, int id);
    }
}
