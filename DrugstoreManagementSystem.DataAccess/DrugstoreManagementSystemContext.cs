using DrugstoreManagementSystem.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DrugstoreManagementSystem.DataAccess
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<User>().Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PasswordHash).IsRequired();

            modelBuilder.Entity<Medicine>().HasKey(x => x.MedicineId);
            modelBuilder.Entity<Medicine>().Property(x => x.MedicineId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Medicine>().Property(x => x.MedicineName).IsRequired();
            modelBuilder.Entity<Medicine>().Property(x => x.PrescriptionRequired).IsRequired();
            modelBuilder.Entity<Medicine>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Medicine>().Property(x => x.ProducerName).IsRequired();
            modelBuilder.Entity<Medicine>().Property(x => x.Quantity).IsRequired();
            modelBuilder.Entity<Medicine>().HasMany(x => x.MedicineSupplyDetails).WithRequired(x => x.Medicine);
            modelBuilder.Entity<Medicine>().HasMany(x => x.MedicineSaleDetails).WithRequired(x => x.Medicine);

            modelBuilder.Entity<Supplier>().HasKey(x => x.SupplierId);
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierName).IsRequired();
            modelBuilder.Entity<Supplier>().HasMany(x => x.Supplies).WithRequired(x => x.Supplier);

            modelBuilder.Entity<Supply>().HasKey(x => x.SupplyId);
            modelBuilder.Entity<Supply>().Property(x => x.SupplyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Supply>().Property(x => x.SupplyDate).IsRequired();
            modelBuilder.Entity<Supply>().Property(x => x.SupplyTotal).IsRequired();
            modelBuilder.Entity<Supply>().HasRequired(x => x.Supplier);

            modelBuilder.Entity<Sale>().HasKey(x => x.SaleId);
            modelBuilder.Entity<Sale>().Property(x => x.SaleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Sale>().Property(x => x.SaleDate).IsRequired();
            modelBuilder.Entity<Sale>().Property(x => x.SaleTotal).IsRequired();

            modelBuilder.Entity<MedicineSupplyDetail>().HasKey(x => x.MedicineSupplyDetailId);
            modelBuilder.Entity<MedicineSupplyDetail>().Property(x => x.MedicineSupplyDetailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MedicineSupplyDetail>().Property(x => x.Quantity).IsRequired();

            modelBuilder.Entity<MedicineSaleDetail>().HasKey(x => x.MedicineSaleDetailId);
            modelBuilder.Entity<MedicineSaleDetail>().Property(x => x.MedicineSaleDetailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MedicineSaleDetail>().Property(x => x.Quantity).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}