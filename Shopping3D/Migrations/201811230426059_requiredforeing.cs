namespace Shopping3D.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredforeing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.SaleLines", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Products", "SaleLine_Id", "dbo.SaleLines");
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            DropIndex("dbo.SaleLines", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "SaleLine_Id" });
            AlterColumn("dbo.Sales", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SaleLines", "Sale_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SaleLine_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "Client_Id");
            CreateIndex("dbo.SaleLines", "Sale_Id");
            CreateIndex("dbo.Products", "SaleLine_Id");
            AddForeignKey("dbo.Sales", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SaleLines", "Sale_Id", "dbo.Sales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SaleLine_Id", "dbo.SaleLines", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SaleLine_Id", "dbo.SaleLines");
            DropForeignKey("dbo.SaleLines", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Products", new[] { "SaleLine_Id" });
            DropIndex("dbo.SaleLines", new[] { "Sale_Id" });
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            AlterColumn("dbo.Products", "SaleLine_Id", c => c.Int());
            AlterColumn("dbo.SaleLines", "Sale_Id", c => c.Int());
            AlterColumn("dbo.Sales", "Client_Id", c => c.Int());
            CreateIndex("dbo.Products", "SaleLine_Id");
            CreateIndex("dbo.SaleLines", "Sale_Id");
            CreateIndex("dbo.Sales", "Client_Id");
            AddForeignKey("dbo.Products", "SaleLine_Id", "dbo.SaleLines", "Id");
            AddForeignKey("dbo.SaleLines", "Sale_Id", "dbo.Sales", "Id");
            AddForeignKey("dbo.Sales", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
