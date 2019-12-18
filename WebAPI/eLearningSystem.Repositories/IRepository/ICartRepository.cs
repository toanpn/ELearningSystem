using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.IRepository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        int GetNumberCart(int id);
        bool CheckExistCart(int? courseId, int id);
    }
}
