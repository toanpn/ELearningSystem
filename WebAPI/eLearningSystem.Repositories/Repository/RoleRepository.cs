using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Repositories.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;
        private readonly IDbSet<Role> _dbset;
        public RoleRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<Role>();
        }

        public Role Add(Role entity)
        {
            var check = _dbset.Any(t => t.Name.Equals(entity.Name));
            if (!check)
                _dbset.Add(entity);
            return entity;
        }

        public void AddNewRole(string nameRole)
        {
            var check = _dbset.Any(t => t.Name.Equals(nameRole));
            if (!check)
            {
                Role role = new Role()
                {
                    Name = nameRole
                };
                _dbset.Add(role);
            }
        }

        public PagedResults<Role> CreatePagedResults(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Role Delete(Role entity)
        {
            _dbset.Remove(entity);
            return entity;
        }

        public void DeleteById(int id)
        {
            var item = _dbset.Find(id);
            if(item != null)
            {
                _dbset.Remove(item);
            }
        }

        public void DeleteRoleByName(string nameRole)
        {
            var role = _dbset.FirstOrDefault(t => t.Name.Equals(nameRole));
            if(role != null)
            {
                _dbset.Remove(role);
            }
        }

        public void Edit(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Role> FindBy(Expression<Func<Role, bool>> predicate)
        {
            IEnumerable<Role> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbset.ToList();
        }

        public Role GetRoleByName(string nameRole)
        {
            return _dbset.FirstOrDefault(t => t.Name.Equals(nameRole));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
