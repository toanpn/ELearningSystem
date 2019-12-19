using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningSystem.Models
{
    class Course
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }
        
        public string ImageUrl { get; set; }

        public bool? IsVisiable { get; set; }
        
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
