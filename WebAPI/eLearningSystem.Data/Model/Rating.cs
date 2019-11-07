namespace eLearningSystem.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? time { get; set; }

        public int? stars { get; set; }

        public bool? is_visible { get; set; }

        [ForeignKey("Course")]
        public int? course_id { get; set; }

        [ForeignKey("User")]
        public string user_id { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
