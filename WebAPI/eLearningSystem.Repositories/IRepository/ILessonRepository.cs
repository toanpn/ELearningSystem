using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        ICollection<Lesson> GetByChapter(int id);
    }
}
