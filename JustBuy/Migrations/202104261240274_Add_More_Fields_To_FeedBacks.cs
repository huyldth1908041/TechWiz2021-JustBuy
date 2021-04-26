namespace JustBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_More_Fields_To_FeedBacks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBacks", "Subject", c => c.String());
            AddColumn("dbo.FeedBacks", "Phone", c => c.String());
            AddColumn("dbo.FeedBacks", "Email", c => c.String());
            AddColumn("dbo.FeedBacks", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedBacks", "Name");
            DropColumn("dbo.FeedBacks", "Email");
            DropColumn("dbo.FeedBacks", "Phone");
            DropColumn("dbo.FeedBacks", "Subject");
        }
    }
}
