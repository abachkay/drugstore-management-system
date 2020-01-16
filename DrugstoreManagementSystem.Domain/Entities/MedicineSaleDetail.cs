namespace DrugstoreManagementSystem.Domain
{
    public class MedicineSaleDetail
    {
        public int MedicineSaleDetailId { get; set; }

        public int? Quantity { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual Medicine Medicine { get; set; }

    }
}