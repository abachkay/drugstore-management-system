using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DrugstoreManagementSystem.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly Func<IUnitOfWork> _getUnitOfWork;

        public SupplierService(Func<IUnitOfWork> getUnitOfWork)
        {
            _getUnitOfWork = getUnitOfWork;
        }

        public IEnumerable<Supplier> GetSuppliers(bool includeArchived = false)
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                return includeArchived ? unitOfWork.SupplierRepository.Get() : unitOfWork.SupplierRepository.Get(m => !m.IsArchived);
            }
        }

        public void ArchiveSupplier(Supplier supplier)
        {
            supplier.IsArchived = true;
        }

        public void SaveChanges(IEnumerable<Supplier> suppliers)
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                unitOfWork.Context.Set<Supplier>().AddOrUpdate(suppliers.ToArray());
                unitOfWork.Save();
            }
        }
    }
}