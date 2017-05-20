namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedManagerToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales");
            DropIndex("dbo.MedicineSaleDetails", new[] { "Medicine_MedicineId" });
            DropIndex("dbo.MedicineSaleDetails", new[] { "Sale_SaleId" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AlterColumn("dbo.Medicines", "MedicineName", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "ProducerName", c => c.String(nullable: false));
            AlterColumn("dbo.MedicineSaleDetails", "Medicine_MedicineId", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicineSaleDetails", "Sale_SaleId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicineSaleDetails", "Medicine_MedicineId");
            CreateIndex("dbo.MedicineSaleDetails", "Sale_SaleId");
            AddForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines", "MedicineId", cascadeDelete: true);
            AddForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales", "SaleId", cascadeDelete: true);
            DropTable("dbo.Managers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
            DropForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines");
            DropIndex("dbo.MedicineSaleDetails", new[] { "Sale_SaleId" });
            DropIndex("dbo.MedicineSaleDetails", new[] { "Medicine_MedicineId" });
            AlterColumn("dbo.MedicineSaleDetails", "Sale_SaleId", c => c.Int());
            AlterColumn("dbo.MedicineSaleDetails", "Medicine_MedicineId", c => c.Int());
            AlterColumn("dbo.Medicines", "ProducerName", c => c.String());
            AlterColumn("dbo.Medicines", "MedicineName", c => c.String());
            DropTable("dbo.Users");
            CreateIndex("dbo.MedicineSaleDetails", "Sale_SaleId");
            CreateIndex("dbo.MedicineSaleDetails", "Medicine_MedicineId");
            AddForeignKey("dbo.MedicineSaleDetails", "Sale_SaleId", "dbo.Sales", "SaleId");
            AddForeignKey("dbo.MedicineSaleDetails", "Medicine_MedicineId", "dbo.Medicines", "MedicineId");
        }
    }
}
