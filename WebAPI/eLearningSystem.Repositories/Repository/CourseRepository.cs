using eLearningSystem.Data.Model;
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

        public ICollection<Course> GetListCourseByListId(ICollection<int?> listId)
        {
            if (listId != null)
                return _dbset.Where(t => listId.Contains(t.Id)).OrderBy(t => t.Id).ToList();
            return null;
        }

        public ICollection<Course> GetListCourseHot()
        {
            return null;
        }

        public ICollection<Course> GetListCourseNew()
        {
            return _dbset.OrderBy(t => t.CreateDate).Take(6).ToList();
        }

        public PagedResults<Course> SearchPageResults(string keyword, int pageNumber, int pageSize)
        {
            var listSearch = _dbset.Where(t => t.Name.ToLower().Contains(keyword.ToLower())).OrderBy(t => t.Id).ToList();

            var skipAmount = pageSize * pageNumber;

            var list = listSearch.Skip(skipAmount).Take(pageSize);

            var totalNumberOfRecords = list.Count();

            var results = list.ToList();

            var mod = totalNumberOfRecords % pageSize;

            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new PagedResults<Course>
            {
                Results = results,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords
            };
        }
    }
}
