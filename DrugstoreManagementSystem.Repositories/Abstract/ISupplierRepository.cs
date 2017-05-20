using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll { get; }
        void Create(Supplier supplier);
        void Delete(Supplier supplier);
    }
}
