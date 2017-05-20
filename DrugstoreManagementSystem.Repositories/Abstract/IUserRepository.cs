using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string login, string password);        
    }
}
