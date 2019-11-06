namespace eLearningSystem.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anwser")]
    public partial class Anwser
    {
        [Key]
        public int id { get; set; }

        public string content { get; set; }

        [StringLength(1)]
        public string type { get; set; }

       [ForeignKey("Question")]
        public int? question_id { get; set; }

        public virtual Question Question { get; set; }
    }
}
