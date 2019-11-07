using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;


namespace eLearningSystem.Services.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(UnitOfWork uow) : base(uow)
        {
        }

        public bool AddUser(string userName, string email, string password)
        {
            uow._userRepository.Insert(new IdentityUser()
            {
                UserName = userName,
                Email = email,
                PasswordHash = Crypto.HashPassword("foo")
            });

            uow.Save();
            return true;
        }

        public bool DeleteUser(string UserId)
        {
            var _user = uow._userRepository.GetById(UserId);
            if(_user == null)
            {
                return false;
            }
            uow._userRepository.Delete(_user);
            return true;
        }

        public IdentityUser GetUsers(string UserId)
        {
            return uow._userRepository.GetById(UserId);
        }

        public IEnumerable<IdentityUser> GetUsersByRole(string RoleId)
        {
            var usersId = uow._userRoleRepository.GetAll().Where(t => t.RoleId == RoleId).Select(t => t.UserId);
            var listUser = uow._userRepository.GetAll().Where(t => usersId.Contains(t.Id)).ToList();
            return listUser;
        }

        public bool UpdateUser(User user)
        {
            uow._userRepository.Update(user);
            return true;
        }
    }
}