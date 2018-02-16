using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Medicine> MedicineRepository { get; }

        IRepository<Supply> SupplyRepository { get; }

        IRepository<Sale> SaleRepository { get; }

        IRepository<Supplier> SupplierRepository { get; }

        IRepository<MedicineSaleDetail> MedicineSaleDetailRepository { get; }

        IRepository<MedicineSupplyDetail> MedicineSupplyDetailRepository { get; }
    }
}