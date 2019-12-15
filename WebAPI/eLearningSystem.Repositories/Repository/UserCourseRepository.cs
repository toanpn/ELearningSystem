﻿using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Repositories.Repository
{
    public class UserCourseRepository : GenericRepository<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(DbContext context) : base(context)
        {
        }

        public List<UserCourse> GetOwnCourses(int userId)
        {
            return this._dbset.Where(m => m.UserId == userId).ToList();
        }
    }
}
