using eLearningSystem.Data.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Model
{
    public class UserQuestion : BaseEntity
    {
        public UserQuestion() : base() { }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("UserTest")]
        public int UserTestId { get; set; }

        public string Answer { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual UserTest UserTest { get; set; }
    }
}
