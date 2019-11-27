namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson() : base()
        {
            Comments = new HashSet<Comment>();
            UserLesson = new HashSet<UserLesson>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        [ForeignKey("Chapter")]
        public int? ChapterId { get; set; }

        public double? VideoTime { get; set; }

        [JsonIgnore]
        public virtual Chapter Chapter { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        //public virtual Video Video { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLesson> UserLesson { get; set; }
    }
}
