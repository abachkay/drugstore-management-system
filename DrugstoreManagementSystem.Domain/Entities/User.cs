namespace DrugstoreManagementSystem.Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }
    }
}