namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rating")]
    public partial class Rating : BaseEntity
    {

        [StringLength(255)]
        public string Content { get; set; }

        public DateTime? Time { get; set; }

        public int? Stars { get; set; }

        public bool? IsVisible { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}