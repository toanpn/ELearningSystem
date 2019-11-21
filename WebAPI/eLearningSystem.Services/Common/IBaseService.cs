using eLearningSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Base
{
    public interface IBaseService<T>
    where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        void DeleteById(int Id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
