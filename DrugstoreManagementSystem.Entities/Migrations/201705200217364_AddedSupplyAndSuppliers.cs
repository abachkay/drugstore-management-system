namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplyAndSuppliers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineSupplyDetails",
                c => new
                    {
                        MedicineSupplyDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Medicine_MedicineId = c.Int(nullable: false),
                        Supply_SupplyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineSupplyDetailId)
                .ForeignKey("dbo.Medicines", t => t.Medicine_MedicineId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.Supply_SupplyId, cascadeDelete: true)
                .Index(t => t.Medicine_MedicineId)
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
            
            AddColumn("dbo.Medicines", "PrescriptionRequired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineSupplyDetails", "Supply_SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.Supplies", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.MedicineSupplyDetails", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.Supplies", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.MedicineSupplyDetails", new[] { "Supply_SupplyId" });
            DropIndex("dbo.MedicineSupplyDetails", new[] { "Medicine_MedicineId" });
            DropColumn("dbo.Medicines", "PrescriptionRequired");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Supplies");
            DropTable("dbo.MedicineSupplyDetails");
        }
    }
}
