using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Entities
{
    public class Supply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplyId { get; set; }
        [Required]
        [DataType("Date")]
        public DateTime SupplyDate { get; set; }
        [Required]
        public decimal SupplyTotal { get; set; }
        [Required]
        public virtual Supplier Supplier { get; set; }
        public virtual ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }
    }
}
