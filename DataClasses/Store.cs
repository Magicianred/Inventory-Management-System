using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("Store")]
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Status Status { get; set; }
    }
}
