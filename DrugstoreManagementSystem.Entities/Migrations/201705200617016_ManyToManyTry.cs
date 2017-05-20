namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplies", "Medicine_MedicineId", c => c.Int());
            CreateIndex("dbo.Supplies", "Medicine_MedicineId");
            AddForeignKey("dbo.Supplies", "Medicine_MedicineId", "dbo.Medicines", "MedicineId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.Supplies", new[] { "Medicine_MedicineId" });
            DropColumn("dbo.Supplies", "Medicine_MedicineId");
        }
    }
}
