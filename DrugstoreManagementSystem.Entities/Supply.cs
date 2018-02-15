using System;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Entities
{
    public class Supply
    {      
        public int SupplyId { get; set; }
     
        public DateTime SupplyDate { get; set; }
    
        public decimal SupplyTotal { get; set; }        
    
        public Supplier Supplier { get; set; }

        public ICollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
    }
}