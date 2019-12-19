using eLearningSystem.Data.Model;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface ICartService : IBaseService<Cart>
    {
        int GetNumberCart(int id);
        bool CheckExistCart(int? courseId, int id);
        ICollection<Cart> GetCartsByUserName(string username);
    }
}
