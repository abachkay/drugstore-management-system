using DrugstoreManagementSystem.DataAccess.Repositories;
using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
                return unitOfWork.SaleRepository.Get(includeProperties: $"{nameof(Sale.MedicineSaleDetails)}.{ nameof(MedicineSaleDetail.Medicine)}").ToList();                
            }
        }

        public void SaveChanges(IEnumerable<Sale> sales)
        {            
            using (var unitOfWork = _getUnitOfWork())
            {
                var storedSales = unitOfWork.SaleRepository.Get(includeProperties: $"{nameof(Sale.MedicineSaleDetails)}.{ nameof(MedicineSaleDetail.Medicine)}").ToList();
                foreach (var sale in sales)
                {
                    var storedSale = storedSales.FirstOrDefault(s => s.SaleId == sale.SaleId);
                    if (storedSale == null)
                    {
                        unitOfWork.Context.Set<Sale>().Add(sale);
                    }
                    else
                    {                        
                        unitOfWork.Context.Entry(storedSale).CurrentValues.SetValues(sale);
                        foreach (var medicineSaleDetail in sale.MedicineSaleDetails)
                        {
                            var storedMedicineSaleDetail = storedSale.MedicineSaleDetails.FirstOrDefault(d =>
                                d.MedicineSaleDetailId == medicineSaleDetail.MedicineSaleDetailId);
                            if (storedMedicineSaleDetail == null)
                            {
                                unitOfWork.Context.Set<MedicineSaleDetail>().Add(medicineSaleDetail);
                            }
                            else
                            {
                                unitOfWork.Context.Entry(storedMedicineSaleDetail).CurrentValues.SetValues(medicineSaleDetail);
                            }
                        }
                    }
                }
                unitOfWork.Save();                
            }
        }        
    }
}