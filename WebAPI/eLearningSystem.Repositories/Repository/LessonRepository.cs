using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eLearningSystem.Repositories.Repository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(DbContext context)
            : base(context)
        {
        }

        public ICollection<Lesson> GetByChapter(int id)
        {
            return _dbset.Where(t => t.ChapterId == id).ToList();
        }
    }
}
