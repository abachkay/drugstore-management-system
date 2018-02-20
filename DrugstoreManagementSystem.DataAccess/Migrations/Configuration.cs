using DrugstoreManagementSystem.Entities;
using System.Data.Entity.Migrations;

namespace DrugstoreManagementSystem.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.DrugstoreManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.DrugstoreManagementSystemContext context)
        {                         
        }
    }
}