namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhantomMigr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supplies", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.Supplies", new[] { "Medicine_MedicineId" });
            DropColumn("dbo.Supplies", "Medicine_MedicineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "Medicine_MedicineId", c => c.Int());
            CreateIndex("dbo.Supplies", "Medicine_MedicineId");
            AddForeignKey("dbo.Supplies", "Medicine_MedicineId", "dbo.Medicines", "MedicineId");
        }
    }
}
