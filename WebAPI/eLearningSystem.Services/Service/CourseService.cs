using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.Models;
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
        IRatingRepository _ratingRepository;

        public CourseService(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IRatingRepository ratingRepository)
            : base(unitOfWork, courseRepository)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
            _ratingRepository = ratingRepository;
        }


        public Course GetById(int Id)
        {
            return _courseRepository.FindBy(x=>x.Id == Id).FirstOrDefault();
        }

        public ICollection<Course> GetListCourseHot()
        {
            var listId = _ratingRepository.GetListIdRatingHighest();
            var listCourse = _courseRepository.GetListCourseByListId(listId);
            return listCourse;
        }

        public PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize)
        {
            return _courseRepository.SearchPageResults(keyword, pageNumber, pageSize);
        }

        public ICollection<Course> GetListCourseNew()
        {
            return _courseRepository.GetListCourseNew();
        }
    }
}
