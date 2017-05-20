using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private DrugstoreManagementSystemContext _context;
        public SqlUserRepository (DrugstoreManagementSystemContext context)
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
