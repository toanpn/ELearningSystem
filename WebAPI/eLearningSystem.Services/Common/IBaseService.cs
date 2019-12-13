using eLearningSystem.Data.Common;
using eLearningSystem.Repositories.Models;
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
        T Create(T entity);
        void Delete(T entity);
        void DeleteById(int Id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        PagedResults<T> CreatePagedResults(int pageNumber, int pageSize);
    }
}
