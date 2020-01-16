using System;
using System.Collections.ObjectModel;

namespace DrugstoreManagementSystem.Domain
{
    public class Sale
    {
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal SaleTotal { get; set; }

        public virtual ObservableCollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
    }
}