namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCourse : BaseEntity
    {
        public UserCourse() : base() { }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public bool? IsOwner { get; set; }

        //[JsonIgnore]
        public virtual Course Course { get; set; }

        //[JsonIgnore]
        public virtual User User { get; set; }
    }
}
