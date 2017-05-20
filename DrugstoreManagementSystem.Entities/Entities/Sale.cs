using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public decimal SaleTotal { get; set; }
        [Required]
        public virtual ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
    }
}