namespace eLearningSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? user_id { get; set; }

        public int? course_id { get; set; }

        public bool? isowner { get; set; }

        public DateTime? datetime { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
