using System.Data.Entity;

namespace DrugstoreManagementSystem.Entities
{
    public class DrugstoreManagementSystemContext : DbContext
    {
        public DrugstoreManagementSystemContext() : base("name=DrugstoreManagementSystem")
        {
        }

        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<MedicineSaleDetail> MedicineSaleDetails { get; set; }
        public virtual DbSet<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
    }
}