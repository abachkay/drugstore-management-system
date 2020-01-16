using System.Collections.ObjectModel;

namespace DrugstoreManagementSystem.Domain
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public virtual ObservableCollection<Supply> Supplies { get; set; }
    }
}