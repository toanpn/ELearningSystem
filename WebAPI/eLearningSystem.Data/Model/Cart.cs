using eLearningSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Model
{
    public partial class Cart : BaseEntity
    {
        public Cart() : base() { }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
