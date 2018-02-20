using System;
using DrugstoreManagementSystem.Entities;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Services
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetMedicines(bool includeArchived = false);

        void ArchiveMedicine(Medicine medicine);

        void SaveChanges(IEnumerable<Medicine> medicines);
    }
}