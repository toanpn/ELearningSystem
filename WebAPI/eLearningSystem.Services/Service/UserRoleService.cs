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
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Services.Service
{
    class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public UserRoleService(IUnitOfWork unitOfWork,
            IUserRoleRepository repository,
            IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _roleRepository = roleRepository;
        }

        public void Create(UserRole entity)
        {
            _repository.AddUserRole(entity);
            _unitOfWork.Commit();
        }

        public void Create(int idUser, int idRole)
        {
            _repository.AddUserRole(idUser, idRole);
            _unitOfWork.Commit();
        }

        public void CreateByNameRole(int idUser, string nameRole)
        {
            var role = _roleRepository.GetRoleByName(nameRole);
            if(role != null)
            {
                _repository.AddUserRole(idUser, role.Id);
                _unitOfWork.Commit();
            }
        }

        public void Delete(UserRole entity)
        {
            _repository.DeleteUserRole(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int idUser, int idRole)
        {
            _repository.DeleteUserRole(idUser, idRole);
            _unitOfWork.Commit();
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
