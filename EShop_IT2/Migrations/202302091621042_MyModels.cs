namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Picture = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        Quantity = c.String(),
                        Rating = c.String(),
                        Brand_BrandId = c.Int(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Brand_BrandId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Products", new[] { "Brand_BrandId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
        }
    }
}
