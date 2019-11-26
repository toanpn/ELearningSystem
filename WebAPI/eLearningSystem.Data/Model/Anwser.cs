namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anwser")]
    public partial class Anwser : BaseEntity
    {
        public Anwser() : base() { }
        public string Content { get; set; }

        [StringLength(1)]
        public string Type { get; set; }

        [ForeignKey("Question")]
        public int? QuestionId { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}
