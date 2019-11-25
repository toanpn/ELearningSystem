using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IQuestionService : IBaseService<Question>
    {
        ICollection<Question> GetListQuestionByTest(int id);
        int GetLastIndex(int id);
        int GetLastId();
    }
}
