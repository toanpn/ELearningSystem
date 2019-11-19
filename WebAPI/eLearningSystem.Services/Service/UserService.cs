using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
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
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _repository;
        IRoleRepository _roleRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _roleRepository = roleRepository;
        }

        public void Create(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var user = _repository.GetById(id);
            if (user == null) throw new ArgumentNullException("id");
            _repository.Delete(user);
            _unitOfWork.Commit();
        }

        IEnumerable<User> IUserService.GetAll()
        {
            return _repository.GetAll();
        }

        User IUserService.GetById(int id)
        {
            return _repository.FindBy(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity.Id, entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<User> GetByRole(int idRole)
        {
            var role = _roleRepository.FindBy(x => x.Id == idRole).First();
            if (role == null) throw new ArgumentNullException("Role");
            return _repository.FindBy(x => x.Roles == role);

        }
    }
}
