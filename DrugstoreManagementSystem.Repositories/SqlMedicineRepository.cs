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
        private readonly DrugstoreManagementSystemContext _dbContext;
        public SqlMedicineRepository()
        {
            _dbContext = new DrugstoreManagementSystemContext();
        }
        public IEnumerable<Medicine> Medicines => _dbContext.Medicines;
       
        public void Add(Medicine medicine, int quantity)
        {
            medicine.Quantity += quantity;
            _dbContext.SaveChanges();
        }

        public void Create(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException("Medicine is empty");
            }
            _dbContext.Medicines.Add(medicine);
            _dbContext.SaveChanges();
        }

        public void Delete(Medicine medicine)
        {
            _dbContext.Medicines.Remove(medicine);
            _dbContext.SaveChanges();
        }
    };          
}
