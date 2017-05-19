using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories.Abstract
{
    interface ISaleRepository
    {
        void Create();
        void Delete();        
        IList<Sale> GetSales { get; }
    }
}
