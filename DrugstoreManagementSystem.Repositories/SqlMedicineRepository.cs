using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories
{
    public class SqlMedicineRepository : IMedicineRepository
    {      
        private readonly DrugstoreManagementSystemContext _context;
        public SqlMedicineRepository(DrugstoreManagementSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Medicine> Medicines => _context.Medicines;

        public IEnumerable<Medicine> GetAll => _context.Medicines;

        public IEnumerable<Medicine> GetAvailible => _context.Medicines.Where(m => m.Quantity > 0);

        public void Add(Medicine medicine, int quantity)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException();
            }
            medicine.Quantity += quantity;
            _context.SaveChanges();
        }

        public void Create(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException();
            }
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }

        public void Delete(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException();
            }
            if (medicine.MedicineSaleDetails.Any() || medicine.MedicineSupplyDetails.Any())
            {
                throw new InvalidOperationException("This medicine is still in some sale or supply.");
            }
            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }
    };          
}
