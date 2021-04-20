using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public virtual Order Order { get; set; }
        public float TotalAmount { get; set; }
    }
}
