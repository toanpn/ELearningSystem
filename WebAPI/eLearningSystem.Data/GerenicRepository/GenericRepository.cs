using eLearningSystem.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.GerenicRepository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private IDbSet<T> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        public GenericRepository(IUnitOfWork<eLearningDataContext> unitOfWork)
        : this(unitOfWork.Context)
        {
        }
        public GenericRepository(eLearningDataContext context)
        {
            _isDisposed = false;
            Context = context;
        }
        public eLearningDataContext Context { get; set; }
        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }
        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }
        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(entity);
                if (Context == null || _isDisposed)
                    Context = new eLearningDataContext();
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be 
                //called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public void BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }
                Context.Configuration.AutoDetectChangesEnabled = false;
                Context.Set<T>().AddRange(entities);
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                        validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new eLearningDataContext();
                SetEntryModified(entity);
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new eLearningDataContext();
                Entities.Remove(entity);
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public virtual void SetEntryModified(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
