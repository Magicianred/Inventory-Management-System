using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public override string ToString()
        {
            return Name;
        }
    }
}
