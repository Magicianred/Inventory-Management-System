using InventoryManagementApp.DataClasses;
using System.Collections.Generic;

namespace InventoryManagementApp.DataRepository
{
    public class InventoryManagementTemporaryBase
    {
        public static List<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
