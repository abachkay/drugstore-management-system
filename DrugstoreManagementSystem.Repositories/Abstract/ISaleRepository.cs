﻿using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll { get; }
        void Create(Sale sale);
        void Delete(Sale sale);            
    }
}
