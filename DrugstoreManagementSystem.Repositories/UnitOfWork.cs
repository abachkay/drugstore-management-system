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
        private SqlMedicineRepository _medicineRepository;
        private SqlSaleRepository _saleRepository;
        private SqlSupplyRepository _supplyRepository;
        private SqlSupplierRepository _supplierRepository;

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new SqlUserRepository(_context));
        public IMedicineRepository MedicineRepository => _medicineRepository ?? (_medicineRepository = new SqlMedicineRepository(_context));
        public ISaleRepository SaleRepository => _saleRepository ?? (_saleRepository = new SqlSaleRepository(_context));
        public ISupplyRepository SupplyRepository => _supplyRepository ?? (_supplyRepository = new SqlSupplyRepository(_context));
        public ISupplierRepository SupplierRepository => _supplierRepository ?? (_supplierRepository = new SqlSupplierRepository(_context));

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
