namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Transaction")]
    public partial class Transaction : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? Time { get; set; }

        public double? TotalPrice { get; set; }

        public double? Paid { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}