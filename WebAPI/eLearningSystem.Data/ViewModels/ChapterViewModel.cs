using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearningSystem.WebApi.ViewModels
{
    public class ChapterViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public String Name { get; set; }
        public int IndexNumber { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
    }
}