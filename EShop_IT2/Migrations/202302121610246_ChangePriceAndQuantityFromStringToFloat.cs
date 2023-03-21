namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceAndQuantityFromStringToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Quantity", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Quantity", c => c.String());
            AlterColumn("dbo.Products", "Price", c => c.String());
        }
    }
}
