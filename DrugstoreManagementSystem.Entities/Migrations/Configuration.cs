namespace DrugstoreManagementSystem.Entities.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DrugstoreManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DrugstoreManagementSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!context.Users.Any())
            {
                var users = new[]
                {
                    new User
                    {
                        Login="abachkay",
                        PasswordHash="428f78bf42693da2f9f4b4ba537c5f101e275607"
                    },
                    new User
                    {
                        Login="johnsmith",
                        PasswordHash="428f78bf42693da2f9f4b4ba537c5f101e275607"
                    },
                };

                context.Users.AddRange(users);
            }
        }
    }
}