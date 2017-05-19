﻿using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public interface IMedicineRepository
    {
        void Create(Medicine medicine);        
        void Delete(Medicine medicine);
        void Add(Medicine medicine, int quantity);
        IEnumerable<Medicine> Medicines { get; }
    }
}