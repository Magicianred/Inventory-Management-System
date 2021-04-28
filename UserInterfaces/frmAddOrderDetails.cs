using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.DataRepository;
using InventoryManagementApp.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmAddOrderDetails : Form
    {
        private bool itemExists = false;
        public frmAddOrderDetails()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateOrderDetailsData())
                {
                    var orderItems = InventoryManagementTemporaryBase.orderItems;
                    var product = (cmbProducts.SelectedItem as Product);

                    foreach (var orderItem in orderItems)
                    {
                        if (orderItem.Product == product)
                        {
                            orderItem.ProductQuantity += int.Parse(nProductQuantity.Value.ToString());
                            orderItem.TotalAmount += float.Parse(lblTotalAmountPrice.Text);
                            itemExists = true;
                        }
                    }
                    if (!itemExists)
                    {
                        InventoryManagementTemporaryBase.orderItems.Add(
                            new OrderItem()
                            {
                                Product = product,
                                ProductQuantity = int.Parse(nProductQuantity.Value.ToString()),
                                ProductPrice = product.ProductPrice,
                                TotalAmount = float.Parse(lblTotalAmountPrice.Text)
                            });
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private bool ValidateOrderDetailsData()
        {
            return cmbProducts.SelectedItem != null
                && nProductQuantity.Value > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
