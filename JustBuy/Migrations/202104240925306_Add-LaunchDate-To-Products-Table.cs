namespace JustBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLaunchDateToProductsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LaunchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LaunchDate");
        }
    }
}
