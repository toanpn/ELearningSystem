namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anwser", "question_id", "dbo.Question");
            DropForeignKey("dbo.Question", "test_id", "dbo.Test");
            DropForeignKey("dbo.User_Test", "test_id", "dbo.Test");
            DropForeignKey("dbo.Lesson", "chapter_id", "dbo.Chapter");
            DropForeignKey("dbo.Test", "chapter_id", "dbo.Chapter");
            DropForeignKey("dbo.Chapter", "course_id", "dbo.Course");
            DropForeignKey("dbo.Rating", "course_id", "dbo.Course");
            DropForeignKey("dbo.User_Course", "course_id", "dbo.Course");
            DropForeignKey("dbo.Course", "category_id", "dbo.Category");
            DropForeignKey("dbo.Comment", "comment_parrent", "dbo.Comment");
            DropForeignKey("dbo.Comment", "lesson_id", "dbo.Lesson");
            DropForeignKey("dbo.User_Lesson", "lesson_id", "dbo.Lesson");
            DropPrimaryKey("dbo.Question");
            DropPrimaryKey("dbo.Test");
            DropPrimaryKey("dbo.Chapter");
            DropPrimaryKey("dbo.Course");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Rating");
            DropPrimaryKey("dbo.Comment");
            DropPrimaryKey("dbo.Lesson");
            DropPrimaryKey("dbo.User_Lesson");
            DropPrimaryKey("dbo.Transaction");
            DropPrimaryKey("dbo.User_Course");
            DropPrimaryKey("dbo.User_Test");
            AlterColumn("dbo.Question", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Test", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Chapter", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Course", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Category", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Rating", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comment", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lesson", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User_Lesson", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Transaction", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User_Course", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User_Test", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Question", "id");
            AddPrimaryKey("dbo.Test", "id");
            AddPrimaryKey("dbo.Chapter", "id");
            AddPrimaryKey("dbo.Course", "id");
            AddPrimaryKey("dbo.Category", "id");
            AddPrimaryKey("dbo.Rating", "id");
            AddPrimaryKey("dbo.Comment", "id");
            AddPrimaryKey("dbo.Lesson", "id");
            AddPrimaryKey("dbo.User_Lesson", "id");
            AddPrimaryKey("dbo.Transaction", "id");
            AddPrimaryKey("dbo.User_Course", "id");
            AddPrimaryKey("dbo.User_Test", "id");
            AddForeignKey("dbo.Anwser", "question_id", "dbo.Question", "id");
            AddForeignKey("dbo.Question", "test_id", "dbo.Test", "id");
            AddForeignKey("dbo.User_Test", "test_id", "dbo.Test", "id");
            AddForeignKey("dbo.Lesson", "chapter_id", "dbo.Chapter", "id");
            AddForeignKey("dbo.Test", "chapter_id", "dbo.Chapter", "id");
            AddForeignKey("dbo.Chapter", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.Rating", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.User_Course", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.Course", "category_id", "dbo.Category", "id");
            AddForeignKey("dbo.Comment", "comment_parrent", "dbo.Comment", "id");
            AddForeignKey("dbo.Comment", "lesson_id", "dbo.Lesson", "id");
            AddForeignKey("dbo.User_Lesson", "lesson_id", "dbo.Lesson", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Lesson", "lesson_id", "dbo.Lesson");
            DropForeignKey("dbo.Comment", "lesson_id", "dbo.Lesson");
            DropForeignKey("dbo.Comment", "comment_parrent", "dbo.Comment");
            DropForeignKey("dbo.Course", "category_id", "dbo.Category");
            DropForeignKey("dbo.User_Course", "course_id", "dbo.Course");
            DropForeignKey("dbo.Rating", "course_id", "dbo.Course");
            DropForeignKey("dbo.Chapter", "course_id", "dbo.Course");
            DropForeignKey("dbo.Test", "chapter_id", "dbo.Chapter");
            DropForeignKey("dbo.Lesson", "chapter_id", "dbo.Chapter");
            DropForeignKey("dbo.User_Test", "test_id", "dbo.Test");
            DropForeignKey("dbo.Question", "test_id", "dbo.Test");
            DropForeignKey("dbo.Anwser", "question_id", "dbo.Question");
            DropPrimaryKey("dbo.User_Test");
            DropPrimaryKey("dbo.User_Course");
            DropPrimaryKey("dbo.Transaction");
            DropPrimaryKey("dbo.User_Lesson");
            DropPrimaryKey("dbo.Lesson");
            DropPrimaryKey("dbo.Comment");
            DropPrimaryKey("dbo.Rating");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Course");
            DropPrimaryKey("dbo.Chapter");
            DropPrimaryKey("dbo.Test");
            DropPrimaryKey("dbo.Question");
            AlterColumn("dbo.User_Test", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.User_Course", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.User_Lesson", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Lesson", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Chapter", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Test", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Question", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.User_Test", "id");
            AddPrimaryKey("dbo.User_Course", "id");
            AddPrimaryKey("dbo.Transaction", "id");
            AddPrimaryKey("dbo.User_Lesson", "id");
            AddPrimaryKey("dbo.Lesson", "id");
            AddPrimaryKey("dbo.Comment", "id");
            AddPrimaryKey("dbo.Rating", "id");
            AddPrimaryKey("dbo.Category", "id");
            AddPrimaryKey("dbo.Course", "id");
            AddPrimaryKey("dbo.Chapter", "id");
            AddPrimaryKey("dbo.Test", "id");
            AddPrimaryKey("dbo.Question", "id");
            AddForeignKey("dbo.User_Lesson", "lesson_id", "dbo.Lesson", "id");
            AddForeignKey("dbo.Comment", "lesson_id", "dbo.Lesson", "id");
            AddForeignKey("dbo.Comment", "comment_parrent", "dbo.Comment", "id");
            AddForeignKey("dbo.Course", "category_id", "dbo.Category", "id");
            AddForeignKey("dbo.User_Course", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.Rating", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.Chapter", "course_id", "dbo.Course", "id");
            AddForeignKey("dbo.Test", "chapter_id", "dbo.Chapter", "id");
            AddForeignKey("dbo.Lesson", "chapter_id", "dbo.Chapter", "id");
            AddForeignKey("dbo.User_Test", "test_id", "dbo.Test", "id");
            AddForeignKey("dbo.Question", "test_id", "dbo.Test", "id");
            AddForeignKey("dbo.Anwser", "question_id", "dbo.Question", "id");
        }
    }
}
