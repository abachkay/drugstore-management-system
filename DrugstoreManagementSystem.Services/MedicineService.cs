using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DrugstoreManagementSystem.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly Func<IUnitOfWork> _getUnitOfWork;

        public MedicineService(Func<IUnitOfWork> getUnitOfWork)
        {
            _getUnitOfWork = getUnitOfWork;
        }

        public IEnumerable<Medicine> GetMedicines(bool includeArchived = false)
        {
            using (var unitOfWork = _getUnitOfWork())
            {                
                return includeArchived ? unitOfWork.MedicineRepository.Get() : unitOfWork.MedicineRepository.Get(m => !m.IsArchived);
            }
        }

        public void ArchiveMedicine(Medicine medicine)
        {
            medicine.IsArchived = true;
        }

        public void SaveChanges(IEnumerable<Medicine> medicines)
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                unitOfWork.Context.Set<Medicine>().AddOrUpdate(medicines.ToArray());
                unitOfWork.Save();               
            }
        }
    }
}