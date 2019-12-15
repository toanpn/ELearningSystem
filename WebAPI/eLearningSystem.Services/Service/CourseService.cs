using eLearningSystem.Data.DTO;
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
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;
        public CourseService(IUnitOfWork unitOfWork, ICourseRepository repository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._courseRepository = repository;
        }
        public PagedResults<Course> CreatePagedResults(int pageNumber, int pageSize)
        {
            return this._courseRepository.CreatePagedResults(pageNumber, pageSize);
        }


    }
}
