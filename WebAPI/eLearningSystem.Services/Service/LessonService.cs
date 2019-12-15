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
    public class LessonService : BaseService<Lesson>, ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonRepository _lessonRepository;
        public LessonService(IUnitOfWork unitOfWork, ILessonRepository repository) : base(unitOfWork, repository)
        {
            this._lessonRepository = repository;
            this._unitOfWork = unitOfWork;
        }
    }
}
