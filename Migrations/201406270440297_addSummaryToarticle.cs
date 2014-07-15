namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSummaryToarticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ArticleSummary", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ArticleSummary");
        }
    }
}
