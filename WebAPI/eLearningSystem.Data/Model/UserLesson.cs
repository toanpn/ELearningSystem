namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserLesson : BaseEntity
    {
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }

        public bool? IsComplete { get; set; }

        public int? Time { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual User User { get; set; }
    }
}