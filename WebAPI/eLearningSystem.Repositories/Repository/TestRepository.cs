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
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        {
        }

        public Test GetTest(int courseId, int chapterId)
        {
            return _dbset.Where(t => t.ChapterId == chapterId && t.CourseId == courseId).FirstOrDefault();
        }
    }
}
