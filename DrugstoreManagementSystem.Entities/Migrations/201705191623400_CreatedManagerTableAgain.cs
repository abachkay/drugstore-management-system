namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedManagerTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Managers");
        }
    }
}
