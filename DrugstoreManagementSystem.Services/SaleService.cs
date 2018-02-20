using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DrugstoreManagementSystem.Services
{
    public class SaleService : ISaleService
    {
        private readonly Func<IUnitOfWork> _getUnitOfWork;

        public SaleService(Func<IUnitOfWork> getUnitOfWork)
        {
            _getUnitOfWork = getUnitOfWork;
        }
        
        public IEnumerable<Sale> GetSales()
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                return unitOfWork.SaleRepository.Get(includeProperties: $"MedicineSaleDetails.Medicine");                
            }
        }

        public void SaveChanges(IEnumerable<Sale> sales)
        {
            using (var unitOfWork = _getUnitOfWork())
            {
                unitOfWork.Context.Set<Sale>().AddOrUpdate(sales.ToArray());
                unitOfWork.Save();
            }
        }        
    }
}