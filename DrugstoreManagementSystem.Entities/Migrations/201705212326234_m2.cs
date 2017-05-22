namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MedicineSupplyDetails", name: "MedicineId", newName: "Medicine_MedicineId");
            RenameIndex(table: "dbo.MedicineSupplyDetails", name: "IX_MedicineId", newName: "IX_Medicine_MedicineId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MedicineSupplyDetails", name: "IX_Medicine_MedicineId", newName: "IX_MedicineId");
            RenameColumn(table: "dbo.MedicineSupplyDetails", name: "Medicine_MedicineId", newName: "MedicineId");
        }
    }
}
