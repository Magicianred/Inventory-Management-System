using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public float TotalAmount { get; set; }
    }
}
