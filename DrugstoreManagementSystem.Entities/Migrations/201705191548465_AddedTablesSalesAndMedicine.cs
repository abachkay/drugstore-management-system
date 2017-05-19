namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTablesSalesAndMedicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.Int(nullable: false),
                        ProducerName = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.MedicineSaleDetails",
                c => new
                    {
                        MedicineSaleDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Medicine_MedicineId = c.Int(),
                        Sale_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicineSaleDetailId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId)
                .ForeignKey("dbo.Sales", t => t.Sale_SaleId)
                .Index(t => t.Medicine_MedicineId)
                .Index(t => t.Sale_SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        SaleTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SaleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.MedicineSaleDetails", new[] { "Sale_SaleId" });
            DropIndex("dbo.MedicineSaleDetails", new[] { "Medicine_MedicineId" });
            DropTable("dbo.Sales");
            DropTable("dbo.MedicineSaleDetails");
            DropTable("dbo.Medicines");
        }
    }
}
