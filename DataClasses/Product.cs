using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Store Store { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
