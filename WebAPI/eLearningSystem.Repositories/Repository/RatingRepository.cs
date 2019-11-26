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
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context)
        {
        }

        public ICollection<int?> GetListIdRatingHighest()
        {
            var list = _dbset.GroupBy(t => t.CourseId)
                                .Select(t => t.Key).Take(6).ToList();
            return list;
        }
    }
}
