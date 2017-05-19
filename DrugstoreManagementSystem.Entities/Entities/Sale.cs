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
        public DateTime SaleDate { get; set; }        
        public decimal SaleTotal { get; set; }
        public virtual ICollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
    }
}