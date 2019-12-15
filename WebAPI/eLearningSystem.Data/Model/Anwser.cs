namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Anwser")]
    public partial class Anwser : BaseEntity
    {
        public string Content { get; set; }

        public string Type { get; set; }

        [ForeignKey("Question")]
        public int? QuestionId { get; set; }

        public Question Question { get; set; }
    }
}