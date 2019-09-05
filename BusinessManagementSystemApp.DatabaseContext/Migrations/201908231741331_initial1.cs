namespace BusinessManagementSystemApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AvailableQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CurrentMRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.Products", "CurrentMRP");
            DropColumn("dbo.Products", "AvailableQuantity");
        }
    }
}
