namespace eLearningSystem.Data.Model
{
    using eLearningSystem.Data.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction : BaseEntity
    {
        public Transaction() : base() { }

        [StringLength(50)]
        public string Name { get; set; }

        public TimeSpan? Time { get; set; }

        public double? TotalPrice { get; set; }

        public double? Paid { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
