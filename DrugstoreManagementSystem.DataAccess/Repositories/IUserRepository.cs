using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.DataAccess.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string login, string password);        
    }
}
