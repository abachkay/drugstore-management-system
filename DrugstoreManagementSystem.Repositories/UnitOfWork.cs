using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed = false;
        private readonly DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();

        private SqlUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new SqlUserRepository(_context));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
