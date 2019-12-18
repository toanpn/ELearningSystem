using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(DbContext context) : base(context)
        {
        }

        public List<Chapter> FindChaptersByCourseId(int courseId)
        {
            return this._dbset.Where(m => m.CourseId == courseId).ToList();
        }
    }
}
