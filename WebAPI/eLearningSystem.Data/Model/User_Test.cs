namespace eLearningSystem.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [ForeignKey("User")]
        public string user_id { get; set; }

        [ForeignKey("Test")]
        public int? test_id { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
    }
}
