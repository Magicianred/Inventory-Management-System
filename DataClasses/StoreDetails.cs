using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementApp.DataClasses
{
    [Table("StoreDetails")]
    public class StoreDetails
    {
        public int Id { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }
        public int UnitsInStock { get; set; }
    }
}
