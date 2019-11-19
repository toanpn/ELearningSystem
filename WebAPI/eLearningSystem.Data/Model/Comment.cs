namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comment")]
    public partial class Comment : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            Comment1 = new HashSet<Comment>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        public int? CommentParent { get; set; }

        public string Content { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(10)]
        public string Stastus { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }

        public int? IndexNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment1 { get; set; }

        public virtual Comment Comment2 { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual User User { get; set; }
    }
}