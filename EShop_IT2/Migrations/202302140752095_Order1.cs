namespace EShop_IT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        Status = c.String(),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
