namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Test")]
    public partial class Test : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            Questions = new HashSet<Question>();
            UserTests = new HashSet<UserTest>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double? Time { get; set; }

        [ForeignKey("Chapter")]
        public int? ChapterId { get; set; }

        public Chapter Chapter { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserTest> UserTests { get; set; }
    }
}