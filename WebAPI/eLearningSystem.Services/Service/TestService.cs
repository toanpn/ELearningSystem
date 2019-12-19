using eLearningSystem.Data.Model;
using eLearningSystem.Data.ViewModels;
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
    public class TestService : BaseService<Test>, ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestRepository _testRepository;
        public TestService(IUnitOfWork unitOfWork, ITestRepository repository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._testRepository = repository;
        }

        public int CheckTest(int courseId, int chapterId, List<SubmitTestViewModel> submitTests)
        {
            int flag = 0;
            Test test = _testRepository.GetTest(courseId, chapterId);
            if (test != null)
            {
                foreach (var question in test.Questions)
                {
                    foreach (var submit in submitTests)
                    {
                        if (submit.QuestionId == question.Id)
                        {
                            if (submit.Key.Equals(question.CorrectAnswer))
                            {
                                flag++;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        public Test GetTest(int courseId, int chapterId)
        {
            return this._testRepository.GetTest(courseId, chapterId);
        }
    }
}
