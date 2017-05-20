using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    class SqlSupplierRepository: ISupplierRepository
    {
        private readonly DrugstoreManagementSystemContext _context;
        public SqlSupplierRepository(DrugstoreManagementSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Supplier> GetAll => _context.Suppliers;            
        public void Create(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            if (supplier.Supplies.Any())
            {
                throw new InvalidOperationException("Can't delete this supplier, because he is still is some supplies.");
            }
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
