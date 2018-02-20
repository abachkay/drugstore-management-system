namespace DrugstoreManagementSystem.Entities
{
    public class MedicineSaleDetail
    {        
        public int MedicineSaleDetailId { get; set; }
        
        public virtual Sale Sale { get; set; }        
        
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }       
    }
}