using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            LoadCategories();
            LoadBrands();
            LoadProducts();
        }

        private void LoadBrands()
        {
            try
            {
                cmbBrands.DataSource = InventoryManagementDb.DB.Brands.ToList();
                cmbBrands.ValueMember = "Id";
                cmbBrands.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategories.DataSource = InventoryManagementDb.DB.Categories.ToList();
                cmbCategories.ValueMember = "Id";
                cmbCategories.DisplayMember = "CategoryName";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
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

                if (e.ColumnIndex == 8)
                {
                    OpenChildForm(new frmAddProduct(product));
                }

                if (e.ColumnIndex == 9
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Products.Remove(product);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
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

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var category = cmbCategories.SelectedItem as Category;
                var brand = cmbBrands.SelectedItem as Brand;

                if (category != null && brand != null)
                {
                    LoadProducts(
                        InventoryManagementDb.DB.Products.Where(p =>
                            (p.ProductName.ToLower().Contains(filter)
                            || p.Description.ToLower().Contains(filter)
                            || string.IsNullOrEmpty(filter))
                            && (p.Category.Id == category.Id
                            && p.Brand.Id == brand.Id)
                            ).ToList());
                }
                else
                {
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cmbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddProduct());
        }

        private void lblClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadProducts();
        }

        private void OpenChildForm(Form form)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(form);
                form.Show();
                this.Hide();
            }
        }
    }
}
