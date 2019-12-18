using eLearningSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);
    }
}
