namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        price = c.Single(nullable: false),
                        qty = c.Int(nullable: false),
                        bill = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShoppingCarts");
        }
    }
}
