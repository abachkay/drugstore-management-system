using DrugstoreManagementSystem.Domain;
using System.Linq;

namespace DrugstoreManagementSystem.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DrugstoreManagementSystemContext _context;

        public UserRepository(DrugstoreManagementSystemContext context)
        {
            _context = context;
        }

        public User GetUser(string login, string password)
        {
            var passwordHash = HashManager.GetHash(password);

            return _context.Users.FirstOrDefault(m => m.Login == login && m.PasswordHash == passwordHash);
        }
    }
}