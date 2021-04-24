namespace JustBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Foreign_Key_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.FeedBacks", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "AppUserId");
            DropColumn("dbo.FeedBacks", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeedBacks", "AppUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "AppUserId", c => c.Int(nullable: false));
            DropColumn("dbo.FeedBacks", "UserId");
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
