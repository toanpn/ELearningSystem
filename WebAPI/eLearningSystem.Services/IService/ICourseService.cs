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
    }
}
