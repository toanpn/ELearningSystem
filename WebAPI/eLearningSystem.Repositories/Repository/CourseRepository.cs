using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eLearningSystem.Repositories.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Course> GetAll()
        {
            return _entities.Set<Course>().AsEnumerable();
        }

    }
}
