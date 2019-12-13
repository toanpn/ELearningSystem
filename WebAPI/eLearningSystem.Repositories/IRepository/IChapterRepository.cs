using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public interface IChapterRepository : IGenericRepository<Chapter>
    {
        ICollection<Chapter> GetByCourse(int id);
    }
}
