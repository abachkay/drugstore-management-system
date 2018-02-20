using System;
using System.Collections.Generic;

namespace DrugstoreManagementSystem.Entities
{
    public class Sale
    {     
        public int SaleId { get; set; }
      
        public DateTime SaleDate { get; set; }
    
        public decimal SaleTotal { get; set; }        

        public ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
    }
}