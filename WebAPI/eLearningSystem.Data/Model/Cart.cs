﻿namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart : BaseEntity
    {
        [ForeignKey("User")]
        public int? user_id { get; set; }

        [ForeignKey("Course")]
        public int? course_id { get; set; }

        public int? quanity { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
