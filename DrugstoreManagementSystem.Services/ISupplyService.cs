using DrugstoreManagementSystem.Entities;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Services
{
    public interface ISupplyService
    {
        IEnumerable<Supply> GetSupplies();        

        void SaveChanges(IEnumerable<Supply> supplies);        
    }
}