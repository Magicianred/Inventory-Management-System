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
    public partial class frmManageProducts : Form
    {
        public frmManageProducts()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false;
        }

        private void frmManageProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategorySearch.DataSource = InventoryManagementDb.DB.Categories.ToList();
            cmbCategorySearch.ValueMember = "Id";
            cmbCategorySearch.DisplayMember = "CategoryName";
        }

        private void LoadProducts(List<Product> products = null)
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products ?? InventoryManagementDb.DB.Products.ToList();

                lblProductsNumber.Text = $"{(dgvProducts.DataSource as List<Product>).Count()} products";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (e.ColumnIndex == 5)
                {
                    Panel pnlChildForm = this.Parent as Panel;

                    if (pnlChildForm != null)
                    {
                        frmAddProduct frmAddProduct = new frmAddProduct(product);
                        frmAddProduct.FormBorderStyle = FormBorderStyle.None;
                        frmAddProduct.TopLevel = false;
                        frmAddProduct.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddProduct);
                        frmAddProduct.Show();
                        this.Hide();
                    }
                }
                if (e.ColumnIndex == 6
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Products.Remove(product);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cmbCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var category = cmbCategorySearch.SelectedItem as Category;

                LoadProducts(
                    InventoryManagementDb.DB.Products.Where(p =>
                        (p.ProductName.ToLower().Contains(filter)
                        || p.Description.ToLower().Contains(filter)
                        || string.IsNullOrEmpty(filter))
                        && p.Category.Id == category.Id).ToList());
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmAddProduct frmAddProduct = new frmAddProduct();
                frmAddProduct.FormBorderStyle = FormBorderStyle.None;
                frmAddProduct.TopLevel = false;
                frmAddProduct.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddProduct);
                frmAddProduct.Show();
                this.Hide();
            }
        }
    }
}
