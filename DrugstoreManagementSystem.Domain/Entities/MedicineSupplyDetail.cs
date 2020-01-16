namespace DrugstoreManagementSystem.Domain
{
    public class MedicineSupplyDetail
    {
        public int MedicineSupplyDetailId { get; set; }

        public int? Quantity { get; set; }

        public virtual Supply Supply { get; set; }

        public virtual Medicine Medicine { get; set; }
    }
}