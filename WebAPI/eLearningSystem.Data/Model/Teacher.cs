using eLearningSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Model
{
    public partial class Teacher : BaseEntity
    {
        public Teacher()
        {
            //Courses = new HashSet<Course>();
        }
        public String Name { get; set; }
        public String Description { get; set; }
        public String UrlImage { get; set; }

        //public ICollection<Course> Courses { get; set; }
    }
}
