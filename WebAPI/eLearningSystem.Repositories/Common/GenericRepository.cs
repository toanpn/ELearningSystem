using eLearningSystem.Data;
using eLearningSystem.Data.Common;
using eLearningSystem.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity 
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void DeleteById(int Id)
        {
            var item = _dbset.Find(Id);
            if(item != null)
            {
                _dbset.Remove(item);
            }
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public PagedResults<T> CreatePagedResults(int pageNumber, int pageSize)
        {
            var list = GetAll();
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<T>
            {
                Results = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = TotalPages,
                TotalNumberOfRecords = count
            };
        }
    }
}
