﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugstoreManagementSystem.Entities;

namespace DrugstoreManagementSystem.Repositories
{
    class SqlSupplyRepository : ISupplyRepository
    {
        private readonly DrugstoreManagementSystemContext _context;
        public SqlSupplyRepository(DrugstoreManagementSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Supply> GetAll => _context.Supplies;

        public void Create(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var smd in supply.MedicineSupplyDetails)
            {
                smd.Medicine.Quantity += smd.Quantity;
                _context.Entry(smd.Medicine).State = System.Data.Entity.EntityState.Modified;
            }
            supply.SupplyTotal = supply.MedicineSupplyDetails.Sum(s => s.Quantity * s.Medicine.Price);
            _context.Supplies.Add(supply);
            _context.SaveChanges();
        }

        public void Delete(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException();
            }
            while (supply.MedicineSupplyDetails.Any())
            {
                supply.MedicineSupplyDetails.Remove(supply.MedicineSupplyDetails.First());
            }
            _context.Supplies.Remove(supply);
            _context.SaveChanges();
        }
    }
}
