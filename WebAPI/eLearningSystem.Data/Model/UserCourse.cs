namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserCourse : BaseEntity
    {
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public bool? IsOwner { get; set; }

        public DateTime? Time { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}