using eLearningSystem.Data.Model;
using System.Collections.Generic;

namespace eLearningSystem.Services.IService
{
    public interface ICourseService
    {
        Course UpserCourse(Course Course);

        IEnumerable<Course> GetCourses();
        Course GetCourseById(int id);
        IEnumerable<Course> GetCoursesByCategory(int categoryId);
        IEnumerable<Course> SearchCoursesByName(string search);

        bool DeleteCourse(int CourseId);

        bool AddCourse(string name, string description, int category_id, int price, string image_url, bool is_visiable);
    }
}