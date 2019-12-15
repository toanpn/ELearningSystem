namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserTest : BaseEntity
    {
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ForeignKey("Test")]
        public int? TestId { get; set; }

        public Test Test { get; set; }

        public User User { get; set; }
    }
}