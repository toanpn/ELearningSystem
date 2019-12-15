namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anwser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Type = c.String(),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scores = c.Int(),
                        TestId = c.Int(),
                        CorrectAnswer = c.String(maxLength: 1),
                        IndexNumber = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Test", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Time = c.Double(),
                        ChapterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapter", t => t.ChapterId)
                .Index(t => t.ChapterId);
            
            CreateTable(
                "dbo.Chapter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        CourseId = c.Int(),
                        IndexNumber = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        Price = c.Double(),
                        ImageUrl = c.String(maxLength: 255),
                        IsVisiable = c.Boolean(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        Time = c.DateTime(),
                        Stars = c.Int(),
                        IsVisible = c.Boolean(),
                        CourseId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 50),
                        Gender = c.Boolean(),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        Score = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentParent = c.Int(),
                        Content = c.String(),
                        Time = c.DateTime(),
                        Stastus = c.String(maxLength: 10),
                        UserId = c.Int(),
                        LessonId = c.Int(),
                        IndexNumber = c.Int(),
                        Comment2_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.Comment2_Id)
                .ForeignKey("dbo.Lesson", t => t.LessonId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.LessonId)
                .Index(t => t.Comment2_Id);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(),
                        VideoUrl = c.String(),
                        ChapterId = c.Int(),
                        VideoTime = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chapter", t => t.ChapterId)
                .Index(t => t.ChapterId);
            
            CreateTable(
                "dbo.UserLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        LessonId = c.Int(),
                        IsComplete = c.Boolean(),
                        Time = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lesson", t => t.LessonId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Date = c.DateTime(storeType: "date"),
                        Time = c.Time(precision: 7),
                        TotalPrice = c.Double(),
                        Paid = c.Double(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CourseId = c.Int(),
                        IsOwner = c.Boolean(),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TestId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Test", t => t.TestId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Anwser", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "TestId", "dbo.Test");
            DropForeignKey("dbo.Test", "ChapterId", "dbo.Chapter");
            DropForeignKey("dbo.Chapter", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Rating", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTests", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTests", "TestId", "dbo.Test");
            DropForeignKey("dbo.UserCourses", "UserId", "dbo.User");
            DropForeignKey("dbo.UserCourses", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Transaction", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.UserLessons", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLessons", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Lesson", "ChapterId", "dbo.Chapter");
            DropForeignKey("dbo.Comment", "Comment2_Id", "dbo.Comment");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.User");
            DropForeignKey("dbo.Rating", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.UserTests", new[] { "TestId" });
            DropIndex("dbo.UserTests", new[] { "UserId" });
            DropIndex("dbo.UserCourses", new[] { "CourseId" });
            DropIndex("dbo.UserCourses", new[] { "UserId" });
            DropIndex("dbo.Transaction", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserLessons", new[] { "LessonId" });
            DropIndex("dbo.UserLessons", new[] { "UserId" });
            DropIndex("dbo.Lesson", new[] { "ChapterId" });
            DropIndex("dbo.Comment", new[] { "Comment2_Id" });
            DropIndex("dbo.Comment", new[] { "LessonId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropIndex("dbo.Rating", new[] { "CourseId" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropIndex("dbo.Chapter", new[] { "CourseId" });
            DropIndex("dbo.Test", new[] { "ChapterId" });
            DropIndex("dbo.Question", new[] { "TestId" });
            DropIndex("dbo.Anwser", new[] { "QuestionId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserTests");
            DropTable("dbo.UserCourses");
            DropTable("dbo.Transaction");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.UserLessons");
            DropTable("dbo.Lesson");
            DropTable("dbo.Comment");
            DropTable("dbo.UserClaims");
            DropTable("dbo.User");
            DropTable("dbo.Rating");
            DropTable("dbo.Category");
            DropTable("dbo.Course");
            DropTable("dbo.Chapter");
            DropTable("dbo.Test");
            DropTable("dbo.Question");
            DropTable("dbo.Anwser");
        }
    }
}
