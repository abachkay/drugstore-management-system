using DrugstoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public interface ISupplyRepository
    {
        IEnumerable<Supply> GetAll { get; }
        void Create(Supply supply);
        void Delete(Supply supply);
    }
}
