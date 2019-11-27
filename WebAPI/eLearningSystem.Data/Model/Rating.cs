namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating : BaseEntity
    {
        public Rating() : base() { }

        [StringLength(255)]
        public string Content { get; set; }

        public int? Stars { get; set; }

        public bool? IsVisible { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
