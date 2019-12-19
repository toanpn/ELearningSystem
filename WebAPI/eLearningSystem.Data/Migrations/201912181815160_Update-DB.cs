namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "Content");
        }
    }
}
