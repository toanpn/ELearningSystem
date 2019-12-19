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
        private readonly ICartRepository _cartRepository;
        private readonly ICourseRepository _courseRepository;
        public UserCourseService(IUnitOfWork unitOfWork,
            IUserCourseRepository repository,
            IUserRepository userRepository,
            ICartRepository cartRepository,
            ICourseRepository courseRepository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._userCourseRepository = repository;
            this._userRepository = userRepository;
            this._cartRepository = cartRepository;
            this._courseRepository = courseRepository;
        }

        public int BuyCourse(int courseId, string userName)
        {
            User user = _userRepository.GetUserByUserName(userName);
            if (user != null)
            {
                Cart cart = _cartRepository.FindBy(t => t.CourseId == courseId && t.UserId == user.Id).FirstOrDefault();
                if (cart != null)
                {
                    UserCourse userCourse = new UserCourse
                    {
                        UserId = user.Id,
                        CourseId = courseId,
                        IsOwner = true,
                        Time = DateTime.Now
                    };
                    this._userCourseRepository.Add(userCourse);

                    _cartRepository.Delete(cart);

                    _unitOfWork.Commit();
                }

            }
            return 1;
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

        public List<int> GetOwnCourseID(string userName)
        {
            List<int> coursesId = new List<int>();

            User user = _userRepository.GetUserByUserName(userName);

            List<UserCourse> userCourses = _userCourseRepository.GetOwnCourses(user.Id);

            if (userCourses.Count > 0)
            {
                foreach (var userCourse in userCourses)
                {
                    coursesId.Add(Convert.ToInt32(userCourse.CourseId));
                }
            }

            return coursesId;
        }
    }
}
