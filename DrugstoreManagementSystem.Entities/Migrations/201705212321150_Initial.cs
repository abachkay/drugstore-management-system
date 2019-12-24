using System.Data.Entity.Migrations;

namespace DrugstoreManagementSystem.Entities.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(nullable: false),
                        ProducerName = c.String(nullable: false),
                        PrescriptionRequired = c.Boolean(nullable: false),
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
                        Medicine_MedicineId = c.Int(nullable: false),
                        Sale_SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineSaleDetailId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_SaleId, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.MedicineSupplyDetails",
                c => new
                    {
                        MedicineSupplyDetailId = c.Int(nullable: false, identity: true),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Supply_SupplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineSupplyDetailId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.Supply_SupplyId, cascadeDelete: true)
                .Index(t => t.MedicineId)
                .Index(t => t.Supply_SupplyId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplyId = c.Int(nullable: false, identity: true),
                        SupplyDate = c.DateTime(nullable: false),
                        SupplyTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier_SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId, cascadeDelete: true)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineSupplyDetails", "Supply_SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.Supplies", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.MedicineSupplyDetails", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.Supplies", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.MedicineSupplyDetails", new[] { "Supply_SupplyId" });
            DropIndex("dbo.MedicineSupplyDetails", new[] { "MedicineId" });
            DropIndex("dbo.MedicineSaleDetails", new[] { "Sale_SaleId" });
            DropIndex("dbo.MedicineSaleDetails", new[] { "Medicine_MedicineId" });
            DropTable("dbo.Users");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Supplies");
            DropTable("dbo.MedicineSupplyDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.MedicineSaleDetails");
            DropTable("dbo.Medicines");
        }
    }
}
