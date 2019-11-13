using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbContext _context;
        private readonly IDbSet<UserRole> _dbset;
        public UserRoleRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<UserRole>();
        }

        public void AddUserRole(int idUser, int idRole)
        {
            var user = _context.Set<User>().Find(idUser);
            var role = _context.Set<Role>().Find(idRole);
            if (user != null && role != null)
            {
                _dbset.Add(new UserRole()
                {
                    RoleId = idRole,
                    UserId = idUser
                });
            }
        }

        public void AddUserRole(UserRole userRole)
        {
            var check = _dbset.Any(t => t.RoleId == userRole.RoleId
                                                    && t.UserId == userRole.UserId);
            if (!check)
            {
                _dbset.Add(userRole);
            }
        }

        public void DeleteUserRole(int idUser, int idRole)
        {
            var userRole = _dbset.FirstOrDefault(t => t.RoleId == idRole
                                                    && t.UserId == idUser);
            if (userRole != null)
            {
                _dbset.Remove(userRole);
            }
        }

        public void DeleteUserRole(UserRole userRole)
        {
            var user = _context.Set<User>().Find(userRole.UserId);
            var role = _context.Set<Role>().Find(userRole.RoleId);
            if(user != null && role != null)
            {
                var value = _dbset.FirstOrDefault(t => t.RoleId == userRole.UserId
                                                    && t.UserId == userRole.UserId);
                if(value != null)
                {
                    _dbset.Remove(value);
                }
            }
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _dbset.ToList();
        }

        public UserRole GetUserRole(int idUser, int idRole)
        {
            return _dbset.FirstOrDefault(t => t.RoleId == idRole
                                && t.UserId == idUser);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
