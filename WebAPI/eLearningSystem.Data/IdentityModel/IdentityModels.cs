using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.Data.Model
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("User")]
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public bool? Gender { get; set; }

        [Column(TypeName = "date")]

        public DateTime? DateOfBirth { get; set; }

        public int? Score { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCourse> UserCourses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLesson> UserLessons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTest> UserTests { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public class UserRole : IdentityUserRole<int>
        {
            public UserRole()
            {
            }
        }

        public class UserClaim : IdentityUserClaim<int>
        {
        }

        public class UserLogin : IdentityUserLogin<int>
        {
        }

        public class Role : IdentityRole<int, UserRole>
        {
            public Role()
            {
            }

            public Role(string name)
            {
                Name = name;
            }
        }

        public class RoleStore : RoleStore<Role, int, UserRole>
        {
            public RoleStore(eLearningDataContext context) : base(context)
            {
            }
        }

        public class UserStore : UserStore<User, Role, int,
            UserLogin, UserRole, UserClaim>
        {
            public UserStore(eLearningDataContext context) : base(context)
            {
            }
        }
    }
}