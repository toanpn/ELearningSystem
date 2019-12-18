using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _repository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
        }
        public User GetUserByUserName(string userName)
        {
            return _repository.GetUserByUserName(userName);
        }
    }
}
