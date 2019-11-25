using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Service
{
    public class QuestionService : BaseService<Question>, IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = repository;
        }

        public int GetLastId()
        {
            return _questionRepository.GetLastId();
        }

        public int GetLastIndex(int id)
        {
            return _questionRepository.GetLastIndex(id);
        }

        public ICollection<Question> GetListQuestionByTest(int id)
        {
            return _questionRepository.GetListQuestionByTest(id);
        }
    }
}
