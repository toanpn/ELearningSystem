using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System.Collections.Generic;

namespace eLearningSystem.Services.IService
{
    public interface IChapterService : IBaseService<Chapter>
    {
        ICollection<Chapter> GetByCourse(int id);
    }
}