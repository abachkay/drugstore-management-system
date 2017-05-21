using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Entities
{
    public class MedicineSupplyDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineSupplyDetailId { get; set; }
        public int MedicineId { get; set; }
        [Required]        
        public virtual Supply Supply { get; set; }
        [Required]
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
