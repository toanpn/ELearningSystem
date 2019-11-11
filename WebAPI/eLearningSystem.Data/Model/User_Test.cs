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

        public int? user_id { get; set; }

        public int? test_id { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
    }
}
