using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
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
    public partial class frmAddOrderDetails : Form
    {
        private Order order;

        public frmAddOrderDetails(Order order)
        {
            InitializeComponent();
            this.order = order;
            nProductQuantity.Minimum = 1;
        }

        private void frmAddOrderDetails_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                cmbProducts.DataSource = InventoryManagementDb.DB.Products.ToList();
                cmbProducts.ValueMember = "Id";
                cmbProducts.DisplayMember = "ProductName";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void nProductQuantity_ValueChanged(object sender, EventArgs e)
        {
            TotalAmountCount();
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalAmountCount();
        }

        private void TotalAmountCount()
        {
            var product = cmbProducts.SelectedItem as Product;
            lblTotalAmountPrice.Text = $"{product.ProductPrice * int.Parse(nProductQuantity.Value.ToString())}";
        }
    }
}
