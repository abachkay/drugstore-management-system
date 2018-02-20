using System;
using System.Collections.Generic;
using System.Data.Entity;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IRepository<Medicine> MedicineRepository { get; }

        IRepository<Supply> SupplyRepository { get; }

        IRepository<Sale> SaleRepository { get; }

        IRepository<Supplier> SupplierRepository { get; }

        IRepository<MedicineSaleDetail> MedicineSaleDetailRepository { get; }

        IRepository<MedicineSupplyDetail> MedicineSupplyDetailRepository { get; }

        void Save();

        IEnumerable<Sale> GetSales();
    }
}