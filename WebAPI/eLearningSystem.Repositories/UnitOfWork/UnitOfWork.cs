using eLearningSystem.Data;
using eLearningSystem.Data.GerenicRepository;
using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private eLearningDataContext _context = null;
        #endregion Private member variables...

        #region Public member variables...
        public IGenericRepository<User> _userRepository { get; set; }
        public IGenericRepository<User_Course> _userCourseRepository { get; set; }
        public IGenericRepository<User_Lesson> _userLessonRepository { get; set; }
        public IGenericRepository<User_Test> _userTestRepository { get; set; }
        public IGenericRepository<Rating> _ratingRepository { get; set; }
        public IGenericRepository<Transaction> _transactionRepository { get; set; }
        public IGenericRepository<Comment> _commentRepository { get; set; }
        public IGenericRepository<Lesson> _lessonRepository { get; set; }
        public IGenericRepository<Course> _courseRepository { get; set; }
        public IGenericRepository<Chapter> _chapterRepository { get; set; }
        public IGenericRepository<Category> _categoryRepository { get; set; }
        public IGenericRepository<Test> _testRepository { get; set; }
        public IGenericRepository<Question> _questionRepository { get; set; }

        #endregion Public member variables...

        public UnitOfWork()
        {
            _context = new eLearningDataContext();
            _userRepository = new GenericRepository<User>(_context);
            _userCourseRepository = new GenericRepository<User_Course>(_context);
            _userLessonRepository = new GenericRepository<User_Lesson>(_context);
            _userTestRepository = new GenericRepository<User_Test>(_context);
            _ratingRepository = new GenericRepository<Rating>(_context);
            _transactionRepository = new GenericRepository<Transaction>(_context);
            _commentRepository = new GenericRepository<Comment>(_context);
            _lessonRepository = new GenericRepository<Lesson>(_context);
            _courseRepository = new GenericRepository<Course>(_context);
            _chapterRepository = new GenericRepository<Chapter>(_context);
            _categoryRepository = new GenericRepository<Category>(_context);
            _testRepository = new GenericRepository<Test>(_context);
            _questionRepository = new GenericRepository<Question>(_context);
        }

        //#region Public Repository Creation properties...

        ///// <summary>
        ///// Get/Set Property for user repository.
        ///// </summary>
        //public IGenericRepository<User> UserRepository
        //{
        //    get
        //    {
        //        if (this._userRepository == null)
        //            this._userRepository = new GenericRepository<User>(_context);
        //        return _userRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for user_course repository.
        ///// </summary>
        //public IGenericRepository<User_Course> UserCourseRepository
        //{
        //    get
        //    {
        //        if (this._userCourseRepository == null)
        //            this._userCourseRepository = new GenericRepository<User_Course>(_context);
        //        return _userCourseRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for user_lesson repository.
        ///// </summary>
        //public IGenericRepository<User_Lesson> UserLessonRepository
        //{
        //    get
        //    {
        //        if (this._userLessonRepository == null)
        //            this._userLessonRepository = new GenericRepository<User_Lesson>(_context);
        //        return _userLessonRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for user_test repository.
        ///// </summary>
        //public IGenericRepository<User_Test> UserTestRepository
        //{
        //    get
        //    {
        //        if (this._userTestRepository == null)
        //            this._userTestRepository = new GenericRepository<User_Test>(_context);
        //        return _userTestRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for rating repository.
        ///// </summary>
        //public IGenericRepository<Rating> RatingRepository
        //{
        //    get
        //    {
        //        if (this._ratingRepository == null)
        //            this._ratingRepository = new GenericRepository<Rating>(_context);
        //        return _ratingRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for transaction repository.
        ///// </summary>
        //public IGenericRepository<Transaction> TransactionRepository
        //{
        //    get
        //    {
        //        if (this._transactionRepository == null)
        //            this._transactionRepository = new GenericRepository<Transaction>(_context);
        //        return _transactionRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for comment repository.
        ///// </summary>
        //public IGenericRepository<Comment> CommentRepository
        //{
        //    get
        //    {
        //        if (this._commentRepository == null)
        //            this._commentRepository = new GenericRepository<Comment>(_context);
        //        return _commentRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for lesson repository.
        ///// </summary>
        //public IGenericRepository<Lesson> LessonRepository
        //{
        //    get
        //    {
        //        if (this._lessonRepository == null)
        //            this._lessonRepository = new GenericRepository<Lesson>(_context);
        //        return _lessonRepository;
        //    }
        //}


        ///// <summary>
        ///// Get/Set Property for course repository.
        ///// </summary>
        //public IGenericRepository<Course> CourseRepository
        //{
        //    get
        //    {
        //        if (this._courseRepository == null)
        //            this._courseRepository = new GenericRepository<Course>(_context);
        //        return _courseRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for chapter repository.
        ///// </summary>
        //public IGenericRepository<Chapter> ChapterRepository
        //{
        //    get
        //    {
        //        if (this._chapterRepository == null)
        //            this._chapterRepository = new GenericRepository<Chapter>(_context);
        //        return _chapterRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for category repository.
        ///// </summary>
        //public IGenericRepository<Category> CategoryRepository
        //{
        //    get
        //    {
        //        if (this._categoryRepository == null)
        //            this._categoryRepository = new GenericRepository<Category>(_context);
        //        return _categoryRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for test repository.
        ///// </summary>
        //public IGenericRepository<Test> TestRepository
        //{
        //    get
        //    {
        //        if (this._testRepository == null)
        //            this._testRepository = new GenericRepository<Test>(_context);
        //        return _testRepository;
        //    }
        //}

        ///// <summary>
        ///// Get/Set Property for question repository.
        ///// </summary>
        //public IGenericRepository<Question> QuestionRepository
        //{
        //    get
        //    {
        //        if (this._questionRepository == null)
        //            this._questionRepository = new GenericRepository<Question>(_context);
        //        return _questionRepository;
        //    }
        //}

        //#endregion Public Repository Creation properties...

        #region Public member methods...

        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
        }

        #endregion Public member methods...

        #region Implementing IDiosposable...

        #region private dispose variable declaration...

        private bool disposed = false;

        #endregion private dispose variable declaration...

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Implementing IDiosposable...
    }
}
