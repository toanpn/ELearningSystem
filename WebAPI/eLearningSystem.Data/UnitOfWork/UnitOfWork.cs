using eLearningSystem.Data.GerenicRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private eLearningDataContext _context = null;
        private GenericRepository<User> _userRepository;
        private GenericRepository<User_Course> _userCourseRepository;
        private GenericRepository<User_Lesson> _userLessonRepository;
        private GenericRepository<User_Test> _userTestRepository;
        private GenericRepository<Rating> _ratingRepository;
        private GenericRepository<Transaction> _transactionRepository;
        private GenericRepository<Comment> _commentRepository;
        private GenericRepository<Lesson> _lessonRepository;
        private GenericRepository<Course> _courseRepository;
        private GenericRepository<Chapter> _chapterRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Test> _testRepository;
        private GenericRepository<Question> _questionRepository;

        #endregion Private member variables...

        public UnitOfWork()
        {
            _context = new eLearningDataContext();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user_course repository.
        /// </summary>
        public GenericRepository<User_Course> UserCourseRepository
        {
            get
            {
                if (this._userCourseRepository == null)
                    this._userCourseRepository = new GenericRepository<User_Course>(_context);
                return _userCourseRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user_lesson repository.
        /// </summary>
        public GenericRepository<User_Lesson> UserLessonRepository
        {
            get
            {
                if (this._userLessonRepository == null)
                    this._userLessonRepository = new GenericRepository<User_Lesson>(_context);
                return _userLessonRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user_test repository.
        /// </summary>
        public GenericRepository<User_Test> UserTestRepository
        {
            get
            {
                if (this._userTestRepository == null)
                    this._userTestRepository = new GenericRepository<User_Test>(_context);
                return _userTestRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for rating repository.
        /// </summary>
        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (this._ratingRepository == null)
                    this._ratingRepository = new GenericRepository<Rating>(_context);
                return _ratingRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for transaction repository.
        /// </summary>
        public GenericRepository<Transaction> TransactionRepository
        {
            get
            {
                if (this._transactionRepository == null)
                    this._transactionRepository = new GenericRepository<Transaction>(_context);
                return _transactionRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for comment repository.
        /// </summary>
        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                if (this._commentRepository == null)
                    this._commentRepository = new GenericRepository<Comment>(_context);
                return _commentRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for lesson repository.
        /// </summary>
        public GenericRepository<Lesson> LessonRepository
        {
            get
            {
                if (this._lessonRepository == null)
                    this._lessonRepository = new GenericRepository<Lesson>(_context);
                return _lessonRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for course repository.
        /// </summary>
        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this._courseRepository == null)
                    this._courseRepository = new GenericRepository<Course>(_context);
                return _courseRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for chapter repository.
        /// </summary>
        public GenericRepository<Chapter> ChapterRepository
        {
            get
            {
                if (this._chapterRepository == null)
                    this._chapterRepository = new GenericRepository<Chapter>(_context);
                return _chapterRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for category repository.
        /// </summary>
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<Category>(_context);
                return _categoryRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for test repository.
        /// </summary>
        public GenericRepository<Test> TestRepository
        {
            get
            {
                if (this._testRepository == null)
                    this._testRepository = new GenericRepository<Test>(_context);
                return _testRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for question repository.
        /// </summary>
        public GenericRepository<Question> QuestionRepository
        {
            get
            {
                if (this._questionRepository == null)
                    this._questionRepository = new GenericRepository<Question>(_context);
                return _questionRepository;
            }
        }

        #endregion Public Repository Creation properties...

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
