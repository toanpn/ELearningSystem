namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLesson : BaseEntity
    {
        public UserLesson() : base() { }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }

        public bool? IsComplete { get; set; }

        public int? Time { get; set; }

        [JsonIgnore]
        public virtual Lesson Lesson { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
