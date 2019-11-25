namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chungchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        question_id = c.Int(nullable: false),
                        user_test_id = c.Int(nullable: false),
                        answer = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Question", t => t.question_id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.user_id, cascadeDelete: true)
                .ForeignKey("dbo.User_Test", t => t.user_test_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.question_id)
                .Index(t => t.user_test_id);
            
            AddColumn("dbo.Question", "content", c => c.String());
            AddColumn("dbo.User_Test", "scores", c => c.Int());
            DropColumn("dbo.Question", "scores");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "scores", c => c.Int());
            DropForeignKey("dbo.User_Question", "user_test_id", "dbo.User_Test");
            DropForeignKey("dbo.User_Question", "user_id", "dbo.User");
            DropForeignKey("dbo.User_Question", "question_id", "dbo.Question");
            DropIndex("dbo.User_Question", new[] { "user_test_id" });
            DropIndex("dbo.User_Question", new[] { "question_id" });
            DropIndex("dbo.User_Question", new[] { "user_id" });
            DropColumn("dbo.User_Test", "scores");
            DropColumn("dbo.Question", "content");
            DropTable("dbo.User_Question");
        }
    }
}
