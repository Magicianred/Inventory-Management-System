using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.DataClasses
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
