using DrugstoreManagementSystem.Entities;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers(bool includeArchived = false);

        void ArchiveSupplier(Supplier supplier);

        void SaveChanges(IEnumerable<Supplier> suppliers);
    }
}