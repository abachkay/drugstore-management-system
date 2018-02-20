namespace DrugstoreManagementSystem.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsArchivedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineSaleDetails", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sales", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineSupplyDetails", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Supplies", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Suppliers", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsArchived");
            DropColumn("dbo.Supplies", "IsArchived");
            DropColumn("dbo.MedicineSupplyDetails", "IsArchived");
            DropColumn("dbo.Sales", "IsArchived");
            DropColumn("dbo.MedicineSaleDetails", "IsArchived");
            DropColumn("dbo.Medicines", "IsArchived");
        }
    }
}
