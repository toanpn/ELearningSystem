using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
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
    public class UserService : BaseService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = repository;
        }
    }
}
