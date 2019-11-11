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
    public class CourseService : BaseService<Course>, ICourseService
    {
        IUnitOfWork _unitOfWork;
        ICourseRepository _courseRepository;

        public CourseService(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
            : base(unitOfWork, courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }


        public Course GetById(int Id)
        {
            return _courseRepository.GetById(Id);
        }
    }
}
