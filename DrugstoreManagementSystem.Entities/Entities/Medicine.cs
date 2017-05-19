using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Entities
{
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }
        public int MedicineName { get; set; }
        public int ProducerName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
    }
}