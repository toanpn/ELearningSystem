using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System.Collections.Generic;

namespace eLearningSystem.Services.IService
{
    public interface ILessonService : IBaseService<Lesson>
    {
        ICollection<Lesson> GetByChapter(int id);
    }
}