using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System.Collections.Generic;

namespace eLearningSystem.Services.IService
{
    public interface ICourseService : IBaseService<Course>
    {
        Course GetById(int Id);
    }
}