namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstnameLastnameToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogUsers", "Firstname", c => c.String(maxLength: 100));
            AddColumn("dbo.BlogUsers", "Lastname", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogUsers", "Lastname");
            DropColumn("dbo.BlogUsers", "Firstname");
        }
    }
}
