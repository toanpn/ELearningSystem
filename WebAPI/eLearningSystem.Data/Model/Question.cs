namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Question")]
    public partial class Question : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Anwsers = new HashSet<Anwser>();
        }

        public int? Scores { get; set; }

        [ForeignKey("Test")]
        public int? TestId { get; set; }

        [StringLength(1)]
        public string CorrectAnswer { get; set; }

        public string Content { get; set; }

        public int? IndexNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anwser> Anwsers { get; set; }

        public Test Test { get; set; }
    }
}