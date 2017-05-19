namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedColumnTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicines", "MedicineName", c => c.String());
            AlterColumn("dbo.Medicines", "ProducerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medicines", "ProducerName", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicines", "MedicineName", c => c.Int(nullable: false));
        }
    }
}
