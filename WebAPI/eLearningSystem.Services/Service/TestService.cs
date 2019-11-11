using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.Repository;
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
    class TestService : BaseService<Test>, ITestService
    {
        IUnitOfWork _unitOfWork;
        ITestRepository _testRepository;

        public TestService(IUnitOfWork unitOfWork, ITestRepository courseRepository)
            : base(unitOfWork, courseRepository)
        {
            _unitOfWork = unitOfWork;
            _testRepository = courseRepository;
        }
    }
}
