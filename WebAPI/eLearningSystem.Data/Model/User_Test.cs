namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Test : BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int id { get; set; }

        [ForeignKey("User")]
        public int? user_id { get; set; }

        [ForeignKey("Test")]
        public int? test_id { get; set; }
        public int? scores { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<User_Question> User_Questions { get; set; }
    }
}
