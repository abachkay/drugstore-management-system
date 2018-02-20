using DrugstoreManagementSystem.Entities;
using System;
using System.Data.Entity;
using System.IO;

namespace DrugstoreManagementSystem.DataAccess.Context
{
    public class DrugstoreManagementSystemContext : DbContext
    {
        public DrugstoreManagementSystemContext() : base("DefaultConnection")
        {
            var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DrugstoreManagementSystem");
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DrugstoreManagementSystem"));            
            Database.SetInitializer(new CreateDatabaseIfNotExists<DrugstoreManagementSystemContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var medicine = modelBuilder.Entity<Medicine>();
            medicine.HasKey(m => m.MedicineId);
            medicine.Property(m => m.MedicineName).IsRequired();
            medicine.Property(m => m.PrescriptionRequired).IsRequired();
            medicine.Property(m => m.Price).IsRequired();
            medicine.Property(m => m.ProducerName).IsRequired();
            medicine.Property(m => m.Quantity).IsRequired();

            var sale = modelBuilder.Entity<Sale>();
            sale.HasKey(s => s.SaleId);
            sale.Property(s => s.SaleDate).IsRequired();
            sale.Property(s => s.SaleTotal).IsRequired();

            var supplier = modelBuilder.Entity<Supplier>();
            supplier.HasKey(s => s.SupplierId);
            supplier.Property(s => s.SupplierName).IsRequired();

            var supply = modelBuilder.Entity<Supply>();
            supply.HasKey(s => s.SupplyId);
            supply.Property(s => s.SupplyDate).IsRequired();
            supply.Property(s => s.SupplyTotal).IsRequired();
            supply.HasRequired(s => s.Supplier).WithMany(s => s.Supplies);

            var medicineSupplyDetails = modelBuilder.Entity<MedicineSupplyDetail>();
            medicineSupplyDetails.Property(msd => msd.Quantity).IsRequired();
            medicineSupplyDetails.HasRequired(m => m.Medicine).WithMany(msd => msd.MedicineSupplyDetails);
            medicineSupplyDetails.HasRequired(m => m.Supply).WithMany(msd => msd.MedicineSupplyDetails);

            var medicineSalsDetails = modelBuilder.Entity<MedicineSaleDetail>();
            medicineSalsDetails.Property(msd => msd.Quantity).IsRequired();            
            medicineSalsDetails.HasRequired(m => m.Medicine).WithMany(msd => msd.MedicineSaleDetails);
            medicineSalsDetails.HasRequired(m => m.Sale).WithMany(msd => msd.MedicineSaleDetails);            
        }     
    }
}