using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories
{
    class SqlSaleRepository : ISaleRepository
    {
        private readonly DrugstoreManagementSystemContext _context;
        public SqlSaleRepository(DrugstoreManagementSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Sale> GetAll => _context.Sales;

        public void Create(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException();
            }
            //sale.SaleTotal = sale.MedicineSaleDetails.Sum(s => s.Quantity * s.Medicine.Price);
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Delete(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException();
            }
            while (sale.MedicineSaleDetails.Any())
            {
                sale.MedicineSaleDetails.Remove(sale.MedicineSaleDetails.First());
            }
            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }
    }
}
