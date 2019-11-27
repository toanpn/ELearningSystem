namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.User", "Image", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Image");
            DropColumn("dbo.User", "Name");
        }
    }
}
