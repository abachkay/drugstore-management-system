using System;
using DrugstoreManagementSystem.DataAccess.Context;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.DataAccess.Repositories
{
    public class SqlUnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DrugstoreManagementSystemContext _context = new DrugstoreManagementSystemContext();
        private IRepository<Medicine> _medicineRepository;
        private IRepository<Supply> _supplyRepository;
        private IRepository<Sale> _saleRepository;
        private IRepository<Supplier> _supplierRepository;
        private IRepository<MedicineSaleDetail> _medicineSaleDetailRepository;
        private IRepository<MedicineSupplyDetail> _medicineSupplyDetailRepository;

        public IRepository<Medicine> MedicineRepository =>
            _medicineRepository ?? (_medicineRepository = new SqlGenericRepository<Medicine>(_context));

        public IRepository<Supply> SupplyRepository =>
            _supplyRepository ?? (_supplyRepository = new SqlGenericRepository<Supply>(_context));

        public IRepository<Sale> SaleRepository =>
            _saleRepository ?? (_saleRepository = new SqlGenericRepository<Sale>(_context));

        public IRepository<Supplier> SupplierRepository =>
            _supplierRepository ?? (_supplierRepository = new SqlGenericRepository<Supplier>(_context));

        public IRepository<MedicineSaleDetail> MedicineSaleDetailRepository =>
            _medicineSaleDetailRepository ?? (_medicineSaleDetailRepository = new SqlGenericRepository<MedicineSaleDetail>(_context));

        public IRepository<MedicineSupplyDetail> MedicineSupplyDetailRepository =>
            _medicineSupplyDetailRepository ?? (_medicineSupplyDetailRepository = new SqlGenericRepository<MedicineSupplyDetail>(_context));


        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable implementation

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}