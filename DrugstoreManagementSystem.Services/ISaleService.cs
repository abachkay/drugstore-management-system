using DrugstoreManagementSystem.Entities;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Services
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetSales();       

        void SaveChanges(IEnumerable<Sale> sales);        
    }
}