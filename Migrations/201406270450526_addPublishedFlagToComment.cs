namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPublishedFlagToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Published", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Published");
        }
    }
}
