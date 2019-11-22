using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
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
        public TestRepository(DbContext context)
             : base(context)
        {

        }

        public override IEnumerable<Test> GetAll()
        {
            return _entities.Set<Test>().AsEnumerable();
        }

        public Test GetTestByChapter(int id)
        {
            return _dbset.FirstOrDefault(t => t.chapter_id == id);
        }
    }
}
