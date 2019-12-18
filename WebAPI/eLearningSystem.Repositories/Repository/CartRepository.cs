using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DbContext context)
            : base(context)
        {

        }

        public override Cart Add(Cart entity)
        {
            var tmp = _dbset.Any(t => t.UserId == entity.UserId && t.CourseId == entity.CourseId);
            if (tmp)
            {
                return null;
            }
            return base.Add(entity);
        }

        public bool CheckExistCart(int? courseId, int id)
        {
            var result = _dbset.Where(t => t.CourseId == courseId && t.UserId == id).FirstOrDefault();
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetNumberCart(int id)
        {
            var tmp = _dbset.Where(t => t.UserId == id).ToList();
            return tmp.Count();
        }
    }
}
