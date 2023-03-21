namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.Int(nullable: false));
            AlterColumn("dbo.Brands", "BrandName", c => c.Int(nullable: false));
        }
    }
}
