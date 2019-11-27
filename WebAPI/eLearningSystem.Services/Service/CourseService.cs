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
            return _courseRepository.FindBy(x => x.Id == Id).FirstOrDefault();
        }

        public ICollection<Course> GetListCourseHot()
        {
            var listId = _ratingRepository.GetListIdRatingHighest();
            var listCourse = _courseRepository.GetListCourseByListId(listId);
            var list = _courseRepository.GetAll();
            foreach (var item in list)
            {
                if (!listCourse.Any(t => t == item))
                {
                    listCourse.Add(item);
                }
            }
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

        public PagedResults<Course> GetListCourseHotPageResult(int pageNumber, int pageSize)
        {
            var list = GetListCourseHot();
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<Course>
            {
                Results = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = TotalPages,
                TotalNumberOfRecords = count
            };
        }

        public PagedResults<Course> GetListCourseNewPageResult(int pageNumber, int pageSize)
        {
            var list = GetListCourseNew();
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<Course>
            {
                Results = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = TotalPages,
                TotalNumberOfRecords = count
            };
        }

        public ICollection<Course> GetListCourseFree()
        {
            return _courseRepository.GetListCourseFree();
        }

        public PagedResults<Course> GetListCourseFreePageResult(int pageNumber, int pageSize)
        {
            var list = GetListCourseFree();
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<Course>
            {
                Results = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = TotalPages,
                TotalNumberOfRecords = count
            };
        }

        public PagedResults<Course> GetListCourseByCategory(int id, int pageNumber, int pageSize)
        {
            var list = _courseRepository.GetListCourseByCategory(id);
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<Course>
            {
                Results = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = TotalPages,
                TotalNumberOfRecords = count
            };
        }
    }
}
