namespace eLearningSystem.Data.Model
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using static eLearningSystem.Data.Model.User;

    public partial class eLearningDataContext : IdentityDbContext<User, Role, int,
    UserLogin, UserRole, UserClaim>
    {
        public eLearningDataContext()
            : base("eLearningDataContext")
        {
        }

        public static eLearningDataContext Create()
        {
            return new eLearningDataContext();
        }

        public DbSet<Anwser> Anwsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserCourse> User_Course { get; set; }
        public DbSet<UserLesson> User_Lesson { get; set; }
        public DbSet<UserTest> User_Test { get; set; }
        //public  DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Anwser>()
            //    .Property(e => e.type)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Courses)
            //    .WithOptional(e => e.Category)
            //    .HasForeignKey(e => e.category_id);

            //modelBuilder.Entity<Chapter>()
            //    .HasMany(e => e.Lessons)
            //    .WithOptional(e => e.Chapter)
            //    .HasForeignKey(e => e.chapter_id);

            //modelBuilder.Entity<Chapter>()
            //    .HasMany(e => e.Tests)
            //    .WithOptional(e => e.Chapter)
            //    .HasForeignKey(e => e.chapter_id);

            //modelBuilder.Entity<Comment>()
            //    .Property(e => e.status)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Comment>()
            //    .HasMany(e => e.Comment1)
            //    .WithOptional(e => e.Comment2)
            //    .HasForeignKey(e => e.comment_parrent);

            //modelBuilder.Entity<Course>()
            //    .HasMany(e => e.Chapters)
            //    .WithOptional(e => e.Course)
            //    .HasForeignKey(e => e.course_id);

            //modelBuilder.Entity<Course>()
            //    .HasMany(e => e.Ratings)
            //    .WithOptional(e => e.Course)
            //    .HasForeignKey(e => e.course_id);

            //modelBuilder.Entity<Course>()
            //    .HasMany(e => e.User_Course)
            //    .WithOptional(e => e.Course)
            //    .HasForeignKey(e => e.course_id);

            //modelBuilder.Entity<Lesson>()
            //    .HasMany(e => e.Comments)
            //    .WithOptional(e => e.Lesson)
            //    .HasForeignKey(e => e.lesson_id);

            //modelBuilder.Entity<Lesson>()
            //    .HasMany(e => e.User_Lesson)
            //    .WithOptional(e => e.Lesson)
            //    .HasForeignKey(e => e.lesson_id);

            //modelBuilder.Entity<Question>()
            //    .Property(e => e.correct_answer)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<Question>()
            //    .HasMany(e => e.Anwsers)
            //    .WithOptional(e => e.Question)
            //    .HasForeignKey(e => e.question_id);

            //modelBuilder.Entity<Test>()
            //    .HasMany(e => e.Questions)
            //    .WithOptional(e => e.Test)
            //    .HasForeignKey(e => e.test_id);

            //modelBuilder.Entity<Test>()
            //    .HasMany(e => e.User_Test)
            //    .WithOptional(e => e.Test)
            //    .HasForeignKey(e => e.test_id);

            //modelBuilder.Entity<User>()
            //    .Property(e => e.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ////modelBuilder.Entity<User>()
            ////    .Property(e => e.email)
            ////    .IsFixedLength();

            //modelBuilder.Entity<User>()
            //    .Property(e => e.phone_number)
            //    .IsFixedLength();

            ////modelBuilder.Entity<User>()
            ////    .Property(e => e.user_role)
            ////    .IsFixedLength();

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Comments)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            //modelBuilder.Entity<User>()
            //   .HasKey(e => e.Id);
            ////.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Ratings)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Transactions)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.User_Course)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.User_Lesson)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.User_Test)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.user_id);

            ////modelBuilder.Entity<Video>()
            ////    .HasMany(e => e.Lessons)
            ////    .WithOptional(e => e.Video)
            ////    .HasForeignKey(e => e.video_url);
            ///
            modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Role>()
            .Property(e => e.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserClaim>()
            .Property(e => e.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserRole>()
            .HasKey(r => new { r.UserId, r.RoleId })
            .ToTable("AspNetUserRoles");

            modelBuilder.Entity<UserLogin>()
                        .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                        .ToTable("AspNetUserLogins");
        }
    }
}