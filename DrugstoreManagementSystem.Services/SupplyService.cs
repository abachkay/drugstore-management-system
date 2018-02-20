using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DrugstoreManagementSystem.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly Func<IUnitOfWork> _getUnitOfWork;

        public SupplyService(Func<IUnitOfWork> getUnitOfWork)
        {
            _getUnitOfWork = getUnitOfWork;
        }

        public IEnumerable<Supply> GetSupplies()
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                return unitOfWork.SupplyRepository.Get(includeProperties: $"{nameof(MedicineSupplyDetail)}.{nameof(Medicine)}");
            }
        }

        public void SaveChanges(IEnumerable<Supply> sales)
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                unitOfWork.Context.Set<Supply>().AddOrUpdate(sales.ToArray());
                unitOfWork.Save();
            }
        }
    }
}