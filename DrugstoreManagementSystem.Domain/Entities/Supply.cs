using System;
using System.Collections.ObjectModel;

namespace DrugstoreManagementSystem.Domain
{
    public class Supply
    {
        public int SupplyId { get; set; }

        public DateTime SupplyDate { get; set; }

        public decimal SupplyTotal { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
    }
}