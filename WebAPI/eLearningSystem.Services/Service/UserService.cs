using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;

namespace eLearningSystem.Services.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(UnitOfWork uow) : base(uow)
        {
        }

        public bool AddUser(long userId, long UserId)
        {
            uow._userRepository.Insert(new User()
            {
                phone_number = "moi"
            });
            uow.Save();
            return true;
        }

        public bool DeleteUser(long UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User UpsertUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}