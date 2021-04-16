using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public DateTime DateAndTime { get; set; }
        public int Quantity { get; set; }
        public float TotalAmount { get; set; }
    }
}
