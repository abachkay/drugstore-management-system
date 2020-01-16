namespace DrugstoreManagementSystem.Domain
{
    public interface IUserRepository
    {
        User GetUser(string login, string password);
    }
}