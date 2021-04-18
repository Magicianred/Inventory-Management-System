using InventoryManagementApp.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmAddProduct : Form
    {
        private Product product;

        public frmAddProduct()
        {
            InitializeComponent();
        }

        public frmAddProduct(Product product)
        {
            this.product = product;
        }
    }
}
