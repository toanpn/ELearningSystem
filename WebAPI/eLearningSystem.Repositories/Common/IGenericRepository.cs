using eLearningSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Common
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindById(object id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(object id, T entity);
        void Save();
    }
}
