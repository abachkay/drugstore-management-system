using System.Collections.Generic;

namespace DrugstoreManagementSystem.Entities
{
    public class Medicine
    {       
        public int MedicineId { get; set; }
     
        public string MedicineName { get; set; }
     
        public string ProducerName { get; set; }
     
        public bool PrescriptionRequired { get; set; }
     
        public decimal Price { get; set; }
     
        public int Quantity { get; set; }       
        
        public bool IsArchived { get; set; }

        public ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }

        public ICollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }       
    }
}