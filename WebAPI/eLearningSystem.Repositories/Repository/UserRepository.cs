using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        private readonly IDbSet<User> _dbset;

        public UserRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<User>();
        }

        public void Add(User user)
        {
            _dbset.Add(user);
        }

        public User Delete(User user)
        {
            return _dbset.Remove(user);
        }

        public void Edit(int id, User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            IEnumerable<User> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbset.AsEnumerable<User>();
        }

        public User GetById(int id)
        {
            return _dbset.Find(id);
        }

        public User GetUserByUserName(string userName)
        {
            return _dbset.FirstOrDefault(t => t.UserName.Equals(userName));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
