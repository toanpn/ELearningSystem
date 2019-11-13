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
    class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork;
        IRoleRepository _repository;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = roleRepository;
        }

        public void Create(Role entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Role entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void DeleteById(int id)
        {
            var role = GetById(id);
            if(role != null)
            {
                _repository.Delete(role);
                _unitOfWork.Commit();
            }
        }

        public void Update(Role entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<Role> GetAll()
        {
            return _repository.GetAll();
        }

        public Role GetById(int id)
        {
            return _repository.FindBy(x => x.Id == id).FirstOrDefault();
        }

        public void DeleteByName(string name)
        {
            _repository.DeleteRoleByName(name);
            _unitOfWork.Commit();
        }
    }
}
