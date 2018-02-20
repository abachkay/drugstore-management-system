namespace DrugstoreManagementSystem.Entities
{
    public class MedicineSupplyDetail
    {     
        public int MedicineSupplyDetailId { get; set; }      
       
        public Supply Supply { get; set; }
      
        public Medicine Medicine { get; set; }
       
        public int Quantity { get; set; }        
    }
}