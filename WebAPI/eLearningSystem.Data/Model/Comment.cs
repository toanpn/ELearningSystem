namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment() : base()
        {
            Comment1 = new HashSet<Comment>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [ForeignKey("Comment2")]
        public int? ParrentId { get; set; }

        public string Content { get; set; }


        [StringLength(10)]
        public string Status { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }

        public int? IndexNum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment1 { get; set; }

        [JsonIgnore]
        public virtual Comment Comment2 { get; set; }

        [JsonIgnore]
        public virtual Lesson Lesson { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
