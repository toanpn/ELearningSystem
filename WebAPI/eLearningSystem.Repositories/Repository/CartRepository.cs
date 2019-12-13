using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            if(tmp) {
                return null;
            }
            return base.Add(entity);
        }

        public int GetNumberCart(int id)
        {
            var tmp = _dbset.Where(t => t.UserId == id).ToList();
            return tmp.Count();
        }
    }
}
