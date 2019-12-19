using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
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
        private readonly ITeacherRepository _teacherRepository;
        public CourseService(IUnitOfWork unitOfWork, ICourseRepository repository, ITeacherRepository teacherRepository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._courseRepository = repository;
            this._teacherRepository = teacherRepository;
        }
        public PagedResults<Course> CreatePagedResults(int pageNumber, int pageSize)
        {
            return this._courseRepository.CreatePagedResults(pageNumber, pageSize);
        }

        public ICollection<Course> GetListCourseHot()
        {
            var listCourse = _courseRepository.GetListCourseNew();
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

        public List<Course> GetListCourseFree()
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

        public Teacher GetTeacherByCourseId(int courseId)
        {
            Course course = _courseRepository.FindById(courseId);
            if (course != null)
            {
                Teacher teacher = _teacherRepository.FindById(course.TeacherId);
                return teacher;
            }
            return null;
        }

        public PagedResults<Course> GetCoursesCategory(int pageNumber, int pageSize, int id)
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
