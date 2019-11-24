using eLearningSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Model
{
    public class User_Question : BaseEntity
    {
        [ForeignKey("User")]
        public int user_id { get; set; }

        [ForeignKey("Question")]
        public int question_id { get; set; }
        [ForeignKey("User_Test")]
        public int user_test_id { get; set; }

        public string answer { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }
        public virtual User_Test User_Test { get; set; }
    }
}
