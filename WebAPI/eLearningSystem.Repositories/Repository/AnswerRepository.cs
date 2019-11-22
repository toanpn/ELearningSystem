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
    public class AnswerRepository : GenericRepository<Anwser>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context)
        {
        }

        public ICollection<Anwser> GetListAnswerByQuestion(int id)
        {
            return _dbset.Where(t => t.question_id == id).ToList();
        }
    }
}
