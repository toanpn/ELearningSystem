namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Lesson : BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        public int? user_id { get; set; }

        public int? lesson_id { get; set; }

        public bool? is_complete { get; set; }

        public int? time { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual User User { get; set; }
    }
}
