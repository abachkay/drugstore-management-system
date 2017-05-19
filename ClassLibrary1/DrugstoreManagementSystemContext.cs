using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DrugstoreManagementSystem.Entities
{
    public class DrugstoreManagementSystemContext:DbContext
    {
        public DrugstoreManagementSystemContext(): base("name=DrugstoreManagementSystem")
        {
        }
        //public virtual DbSet<Car> Cars { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Manager> Managers { get; set; }
        //public virtual DbSet<Order> Orders { get; set; }
    }
}
