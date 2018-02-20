namespace DrugstoreManagementSystem.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedNonRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MedicineSaleDetails", "IsArchived");
            DropColumn("dbo.Sales", "IsArchived");
            DropColumn("dbo.MedicineSupplyDetails", "IsArchived");
            DropColumn("dbo.Supplies", "IsArchived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineSupplyDetails", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sales", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.MedicineSaleDetails", "IsArchived", c => c.Boolean(nullable: false));
        }
    }
}
