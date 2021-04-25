namespace JustBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ShipingFee_To_Orders_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingFee");
        }
    }
}
