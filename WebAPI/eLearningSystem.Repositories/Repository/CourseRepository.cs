﻿using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.Models;
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

        public ICollection<Course> GetListCourseByCategory(int id)
        {
            return _dbset.Where(t => t.CategoryId == id).ToList();
        }

        public ICollection<Course> GetListCourseByListId(ICollection<int?> listId)
        {
            if (listId != null)
                return _dbset.Where(t => listId.Contains(t.Id)).OrderBy(t => t.Id).ToList();
            return null;
        }

        public ICollection<Course> GetListCourseFree()
        {
            return null;
        }

        public ICollection<Course> GetListCourseHot()
        {
            return null;
        }

        public ICollection<Course> GetListCourseNew()
        {
            return _dbset.OrderBy(t => t.CreateDate).ToList();
        }

        public PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize)
        {
            
            var list = _dbset.Where(t => t.Name.ToLower().Contains(keyword.ToLower())).OrderBy(t => t.Id).ToList();
            int count = list.Count();
            int CurrentPage = pageNumber;
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = list.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResults<Course>
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
