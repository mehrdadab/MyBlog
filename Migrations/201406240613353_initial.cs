namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogUsers",
                c => new
                    {
                        BlogUserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(maxLength: 100),
                        JointDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogUserId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogName = c.String(maxLength: 200),
                        Subject = c.String(nullable: false, maxLength: 200),
                        NumOfArticlesInFirstPage = c.Int(nullable: false),
                        SummaryLength = c.Int(nullable: false),
                        BlogDate = c.DateTime(nullable: false),
                        BlogUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.BlogUsers", t => t.BlogUserId, cascadeDelete: true)
                .Index(t => t.BlogUserId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(maxLength: 1000),
                        ArticleContent = c.String(nullable: false),
                        ArticleDate = c.DateTime(nullable: false),
                        ArticleKeywords = c.String(maxLength: 500),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Fullname = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        CommentContent = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "BlogUserId" });
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogUserId", "dbo.BlogUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogUsers");
        }
    }
}
