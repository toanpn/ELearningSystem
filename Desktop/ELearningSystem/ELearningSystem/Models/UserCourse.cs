using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningSystem.Models
{
    class UserCourse
    {
        public int? UserId { get; set; }
        
        public int? CourseId { get; set; }

        public bool? IsOwner { get; set; }

        public DateTime? Time { get; set; }

        public Course Course { get; set; }

        public User User { get; set; }
    }
}
