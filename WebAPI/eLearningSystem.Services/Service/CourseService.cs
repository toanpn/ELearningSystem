using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using System;
using System.Linq;
using System.Collections.Generic;

namespace eLearningSystem.Services.Service
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(UnitOfWork uow) : base(uow)
        {
        }

        public bool AddCourse(string name, string description, int category_id, int price, string image_url, bool is_visiable)
        {
            uow._courseRepository.Insert(new Course()
            {
                name = name,
                description = description,
                category_id = category_id,
                price = price,
                image_url = image_url,
                is_visiable = is_visiable,
            });
            uow.Save();
            return true;
        }

        public bool DeleteCourse(int CourseId)
        {
            uow._courseRepository.Delete(CourseId);
            return true;
        }

        public Course GetCourseById(int id)
        {
            return uow._courseRepository.GetAll().FirstOrDefault(x=>x.id == id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return uow._courseRepository.GetAll();
        }

        public IEnumerable<Course> GetCoursesByCategory(int categoryId)
        {
            return uow._courseRepository.GetAll().Where(x => x.category_id == categoryId);
        }

        public IEnumerable<Course> SearchCoursesByName(string search)
        {
            return uow._courseRepository.GetAll().Where(x => x.name.Contains(search));
        }

        public Course UpserCourse(Course Course)
        {
            uow._courseRepository.Update(Course);
            return Course;
        }
    }
}