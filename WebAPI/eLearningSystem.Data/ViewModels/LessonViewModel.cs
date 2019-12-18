using eLearningSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearningSystem.WebApi.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String VideoUrl { get; set; }
        public double? VideoTime { get; set; }
    }
}