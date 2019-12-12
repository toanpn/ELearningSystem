using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eLearningSystem.Repositories.Repository
{
    public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(DbContext context)
            : base(context)
        {

        }

        public ICollection<Chapter> GetByCourse(int id)
        {
            return _dbset.Where(t => t.CourseId == id).ToList();
        }

        //public override IEnumerable<Chapter> GetAll()
        //{
        //    return _entities.Set<Chapter>().AsEnumerable();
        //}

    }
}
