namespace Shopping3D.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.SaleLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductQuantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(nullable: false),
                        Sale_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Image = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleLines", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SaleLines", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Sales", "Client_Id", "dbo.Clients");
            DropIndex("dbo.SaleLines", new[] { "Sale_Id" });
            DropIndex("dbo.SaleLines", new[] { "Product_Id" });
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.SaleLines");
            DropTable("dbo.Sales");
            DropTable("dbo.Clients");
        }
    }
}
