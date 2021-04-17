using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementApp.Users
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
    }
}
