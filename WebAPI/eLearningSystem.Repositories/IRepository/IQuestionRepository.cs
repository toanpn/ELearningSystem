using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.IRepository
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        ICollection<Question> GetListQuestionByTest(int id);
        int GetLastIndex(int id);
        int GetLastId();
    }
}
