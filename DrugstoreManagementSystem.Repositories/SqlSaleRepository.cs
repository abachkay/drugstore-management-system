using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;
using System.Data.Entity;

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
            foreach (var smd in sale.MedicineSaleDetails)
            {
                smd.Medicine.Quantity -= smd.Quantity;
                _context.Entry(smd.Medicine).State = System.Data.Entity.EntityState.Modified;
            }
            sale.SaleTotal = sale.MedicineSaleDetails.Sum(s => s.Quantity * s.Medicine.Price);
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
                _context.Entry(sale.MedicineSaleDetails.First()).State = EntityState.Deleted;                
            }
            _context.Entry(sale).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
