using eLearningSystem.Data.Model;
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
    public class LessonService : BaseService<Lesson>, ILessonService
    {
        IUnitOfWork _unitOfWork;
        ILessonRepository _lessonRepository;

        public LessonService(IUnitOfWork unitOfWork, ILessonRepository lessonRepository)
            : base(unitOfWork, lessonRepository)
        {
            _unitOfWork = unitOfWork;
            _lessonRepository = lessonRepository;
        }

        public ICollection<Lesson> GetByChapter(int id)
        {
            return _lessonRepository.GetByChapter(id);
        }
    }
}
