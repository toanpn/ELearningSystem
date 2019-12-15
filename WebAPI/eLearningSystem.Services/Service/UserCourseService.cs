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
    public class UserCourseService : BaseService<UserCourse>, IUserCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        public UserCourseService(IUnitOfWork unitOfWork,
            IUserCourseRepository repository,
            IUserRepository userRepository,
            ICourseRepository courseRepository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._userCourseRepository = repository;
            this._userRepository = userRepository;
            this._courseRepository = courseRepository;
        }

        public List<Course> GetOwnCourses(string userName)
        {
            List<Course> courses = new List<Course>();

            User user = _userRepository.GetUserByUserName(userName);

            List<UserCourse> userCourses = _userCourseRepository.GetOwnCourses(user.Id);

            if (userCourses.Count > 0)
            {
                foreach (var userCourse in userCourses)
                {
                    Course course = _courseRepository.FindById(userCourse.CourseId);
                    courses.Add(course);
                }
            }

            return courses;
        }
    }
}
