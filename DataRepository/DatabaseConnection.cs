using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Data
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection() : base("DatabasePath")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreDetails> StoreDetails { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }

    }
}
