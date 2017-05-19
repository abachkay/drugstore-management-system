using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Entities
{
    public class MedicineSaleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineSaleDetailId { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
}