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
    public class AnswerService : BaseService<Anwser>, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork, IAnswerRepository repository) : base(unitOfWork, repository)
        {
            _answerRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public ICollection<Anwser> GetListAnswerByQuestion(int id)
        {
            return _answerRepository.GetListAnswerByQuestion(id);
        }
    }
}
