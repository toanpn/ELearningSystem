namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Course")]
    public partial class Course : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            Ratings = new HashSet<Rating>();
            UserCourses = new HashSet<UserCourse>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public double? Discount { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public bool? IsVisiable { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }


        public Category Category { get; set; }
        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Chapter> Chapters { get; set; }

        public ICollection<Test> Tests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Rating> Ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}