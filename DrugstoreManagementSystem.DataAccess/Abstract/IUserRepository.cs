using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories.Abstract
{
    public interface IUserRepository
    {
        User GetUser(string login, string password);        
    }
}
