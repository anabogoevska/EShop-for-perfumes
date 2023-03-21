namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBaseChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Rating", c => c.String());
        }
    }
}
