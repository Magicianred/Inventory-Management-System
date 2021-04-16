﻿using InventoryManagementApp.DataClasses;
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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
