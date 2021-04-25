namespace JustBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_UserId_To_String : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.FeedBacks", new[] { "User_Id" });
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.FeedBacks", "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.FeedBacks", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FeedBacks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.FeedBacks", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeedBacks", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.FeedBacks", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FeedBacks", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            AddColumn("dbo.FeedBacks", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.FeedBacks", "User_Id");
            CreateIndex("dbo.Orders", "User_Id");
        }
    }
}
