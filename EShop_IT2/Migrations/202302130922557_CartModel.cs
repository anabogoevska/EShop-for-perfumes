namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.Carts", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_ProductID" });
            DropTable("dbo.Carts");
        }
    }
}
