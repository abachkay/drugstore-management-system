using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DrugstoreManagementSystem.DataAccess.Repositories
{
    public class SqlUnitOfWork : IUnitOfWork
    {        
        public SqlUnitOfWork(DbContext context)
        {
            Context = context;
            MedicineRepository = new SqlGenericRepository<Medicine>(context);
            SupplyRepository = new SqlGenericRepository<Supply>(context);
            SupplierRepository = new SqlGenericRepository<Supplier>(context);
            SaleRepository = new SqlGenericRepository<Sale>(context);
            MedicineSaleDetailRepository = new SqlGenericRepository<MedicineSaleDetail>(context);
            MedicineSupplyDetailRepository = new SqlGenericRepository<MedicineSupplyDetail>(context);
        }

        public IEnumerable<Sale> GetSales()
        {
            return Context.Set<Sale>().ToList();
        }

        public DbContext Context { get; }

        public IRepository<Medicine> MedicineRepository { get; }

        public IRepository<Supply> SupplyRepository { get; }

        public IRepository<Sale> SaleRepository { get; }

        public IRepository<Supplier> SupplierRepository { get; }

        public IRepository<MedicineSaleDetail> MedicineSaleDetailRepository { get; }

        public IRepository<MedicineSupplyDetail> MedicineSupplyDetailRepository { get; }


        public void Save()
        {
            Context.SaveChanges();
        }

        #region IDisposable implementation

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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