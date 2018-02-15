using System.Linq;
using DrugstoreManagementSystem.DataAccess.Context;
using DrugstoreManagementSystem.Entities;
using DrugstoreManagementSystem.Repositories.Abstract;
using DrugstoreManagementSystem.Repositories.Helpers;

namespace DrugstoreManagementSystem.Repositories.Concrete
{
    //public class SqlUserRepository : IUserRepository
    //{
    //    private readonly DrugstoreManagementSystemContext _context;

    //    public SqlUserRepository (DrugstoreManagementSystemContext context)
    //    {
    //        _context = context;
    //    }

    //    //public User GetUser(string login, string password)
    //    //{
    //    //    var passwordHash = HashManager.GetHash(password);

    //    //    return _context.Users.FirstOrDefault(m => m.Login == login && m.PasswordHash == passwordHash);            
    //    //}
    //}
}
