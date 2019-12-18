using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        PagedResults<Course> CreatePagedResults(int pageNumber, int pageSize);

        PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize);
        ICollection<Course> GetListCourseNew();
        ICollection<Course> GetListCourseByListId(ICollection<int?> listId);
        List<Course> GetListCourseFree();
        ICollection<Course> GetListCourseByCategory(int id);
    }
}
