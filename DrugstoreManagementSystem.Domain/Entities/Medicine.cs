using System.Collections.ObjectModel;

namespace DrugstoreManagementSystem.Domain
{
    public class Medicine
    {
        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        public string ProducerName { get; set; }

        public bool PrescriptionRequired { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public virtual ObservableCollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }

        public virtual ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
    }
}