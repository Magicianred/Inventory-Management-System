using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Data
{
    public class InventoryManagementDb
    {
        public static DatabaseConnection DB { get; set; } = new DatabaseConnection();
    }
}
