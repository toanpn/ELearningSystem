//namespace eLearningSystem.Data.Model
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("User")]
//    public partial class User
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public User()
//        {
//            Comments = new HashSet<Comment>();
//            Ratings = new HashSet<Rating>();
//            Transactions = new HashSet<Transaction>();
//            User_Course = new HashSet<User_Course>();
//            User_Lesson = new HashSet<User_Lesson>();
//            User_Test = new HashSet<User_Test>();
//        }

//        public int id { get; set; }

//        [StringLength(20)]
//        public string user_name { get; set; }

//        [StringLength(30)]
//        public string email { get; set; }

//        [StringLength(20)]
//        public string phone_number { get; set; }

//        [StringLength(50)]
//        public string address { get; set; }

//        public bool? gender { get; set; }

//        [Column(TypeName = "date")]
//        public DateTime? birth_day { get; set; }

//        [StringLength(10)]
//        public string user_role { get; set; }

//        public int? scores { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Comment> Comments { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Rating> Ratings { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Transaction> Transactions { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<User_Course> User_Course { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<User_Lesson> User_Lesson { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<User_Test> User_Test { get; set; }
//    }
//}
