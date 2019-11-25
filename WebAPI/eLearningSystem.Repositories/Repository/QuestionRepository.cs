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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }

        public int GetLastId()
        {
            return _dbset.Max(t => t.id);
        }

        public int GetLastIndex(int id)
        {
            var last = _dbset.Where(t => t.test_id == id).Max(t => t.index_num);
            var max = 0;
            if (last != null)
            {
                max = last.GetValueOrDefault();
            }
            return max;
        }

        public ICollection<Question> GetListQuestionByTest(int id)
        {
            return _dbset.Where(t => t.test_id == id).ToList();
        }
    }
}
