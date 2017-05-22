using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        [DefaultValue(1)]
        public int MedicineId { get; set; }
        [Required]
        [DefaultValue("Name")]
        public string MedicineName { get; set; }
        [Required]
        [DefaultValue("Producer")]
        public string ProducerName { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool PrescriptionRequired { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }        
        public virtual ObservableCollection<MedicineSaleDetail> MedicineSaleDetails { get; set; }
        public virtual ObservableCollection<MedicineSupplyDetail> MedicineSupplyDetails { get; set; }       
    }
}