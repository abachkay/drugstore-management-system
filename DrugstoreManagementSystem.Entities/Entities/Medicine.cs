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
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public string ProducerName { get; set; }
        [Required]
        public bool PrescriptionRequired { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }        
        public virtual ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
        public virtual ICollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
       // public virtual ICollection<Supply> Supplies { get; set; }
    }
}