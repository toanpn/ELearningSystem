namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating : BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? time { get; set; }

        public int? stars { get; set; }

        public bool? is_visible { get; set; }

        public int? course_id { get; set; }

        public int? user_id { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
