namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTest : BaseEntity
    {
        public UserTest() : base() { }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Test")]
        public int? TestId { get; set; }
        public int? Scores { get; set; }

        [JsonIgnore]
        public virtual Test Test { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}
