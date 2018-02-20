using System.Collections.Generic;

namespace DrugstoreManagementSystem.Entities
{
    public class Supplier
    {      
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public bool IsArchived { get; set; }

        public ICollection<Supply> Supplies { get; set; }
    }
}